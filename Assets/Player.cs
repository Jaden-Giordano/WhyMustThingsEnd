using UnityEngine;
using System.Collections;

public class Player : MorphingPoly {

    protected Timer pointsAdder;

    [SerializeField]
    protected float pointAddition = 3f;

    [SerializeField]
    protected int unspentPoints;

    public float zoom = 1f;

    protected override void init() {
        base.init();

        pointsAdder = new Timer();
        unspentPoints = 0;

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
