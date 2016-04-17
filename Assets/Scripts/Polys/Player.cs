using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MorphingPoly {

    protected Timer pointsAdder;

    [SerializeField]
    protected float pointAddition = 8f;

    [SerializeField]
    protected int unspentPoints;

    public GameObject uiPanel;

    public float zoom = 1f;

    protected override void init() {
        base.init();

        pointsAdder = new Timer();
        unspentPoints = 1;

        this.gameObject.tag = "Player";
    }

    bool first = true;
    protected override void tick() {
        if (first) {
            this.GetComponent<MeshRenderer>().sharedMaterial = Constants.vertexColorMat;
            first = false;
        }
        if (pointsAdder.elapsedTime > pointAddition) {
            unspentPoints++;
            pointsAdder.Reset();
        }
        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, new Vector3(this.transform.position.x, this.transform.position.y, Camera.main.transform.position.z), .1f);
        float prz = this.zoom;
        this.zoom = .1f + (this.maxHealth/10)/2;
        float z = Vector2.Lerp(new Vector2(prz, 0), new Vector2(zoom, 0), .1f).x;
        Camera.main.orthographicSize = 18*z;
        if (Input.GetKeyUp(KeyCode.Alpha1)) {
            SpendSkillPoint(MorphType.Shape);
        }
        if (Input.GetKeyUp(KeyCode.Alpha2)) {
            SpendSkillPoint(MorphType.Movement);
        }
        if (Input.GetKeyUp(KeyCode.Alpha3)) {
            SpendSkillPoint(MorphType.Rotation);
        }
        if (Input.GetKeyUp(KeyCode.Alpha4)) {
            SpendSkillPoint(MorphType.Projectiles);
        }
        if (Input.GetKeyUp(KeyCode.Alpha5)) {
            SpendSkillPoint(MorphType.Shields);
        }
        if (Input.GetKeyUp(KeyCode.Alpha6)) {
            SpendSkillPoint(MorphType.Health);
        }

        Text uep = uiPanel.transform.GetChild(0).GetComponent<Text>();
        uep.text = "Unspent Evolution Points: " + unspentPoints;

        Text shape = uiPanel.transform.GetChild(1).GetChild(0).GetComponent<Text>();
        shape.text = "Morph \n\r" + morphTypeCount[0];

        Text move = uiPanel.transform.GetChild(2).GetChild(0).GetComponent<Text>();
        move.text = "Move \n\r" + morphTypeCount[1];

        Text rot = uiPanel.transform.GetChild(3).GetChild(0).GetComponent<Text>();
        rot.text = "Rotation \n\r" + morphTypeCount[2];

        Text proj = uiPanel.transform.GetChild(4).GetChild(0).GetComponent<Text>();
        proj.text = "Project. \n\r" + morphTypeCount[3];

        Text shields = uiPanel.transform.GetChild(5).GetChild(0).GetComponent<Text>();
        shields.text = "Shields \n\r" + morphTypeCount[4];

        Text hp = uiPanel.transform.GetChild(6).GetChild(0).GetComponent<Text>();
        hp.text = "Health \n\r" + morphTypeCount[5];
    }

    public virtual void SpendSkillPoint(MorphType mtype) {
        if (unspentPoints > 0) {
            Morph(mtype);
            unspentPoints--;
        }
    }

    public virtual void AddSkillPoints(int amt) {
        this.unspentPoints += amt;
    }

}
