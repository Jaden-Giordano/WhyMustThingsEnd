using UnityEngine;
using System.Collections;

public enum PolyType {
    Triangle = 3,
    Rectangle = 4,
    Pentagon = 5,
    Hexagon = 6,
    Octagon = 8
}

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(PolygonCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Poly : MonoBehaviour {

    protected PolyType ptype;

    protected Timer invTimer;

    public float health;
    [SerializeField]
    protected float maxHealth;

	void Awake() {
        init();
    }

    protected virtual void init() {
        this.GetComponent<MeshFilter>().mesh = PolyTool.CreateTriangle();
        this.GetComponent<PolygonCollider2D>().points = PolyTool.CreateTriangleCollider();
        this.GetComponent<MeshRenderer>().sharedMaterial = Constants.vertexColorMat;
        this.ptype = PolyType.Triangle;

        this.GetComponent<Rigidbody2D>().gravityScale = 0;
        this.GetComponent<Rigidbody2D>().mass = 0.00001f;
        this.GetComponent<Rigidbody2D>().freezeRotation = true;
        this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;

        this.health = 5;
        this.maxHealth = 5;

        this.transform.localScale = new Vector3(maxHealth / 10, maxHealth / 10, maxHealth / 10);

        this.tag = "Poly";

        this.invTimer = new Timer();
    }

    void Update() {
        tick();
    }

    protected virtual void tick() {
        this.GetComponent<MeshFilter>().mesh.colors = PolyTool.SetColor(this.ptype, new Color(255 - (255 * (this.health / 10)), 255 * (this.health / 10), 0));
    }

    public virtual PolyType GetPolyType() {
        return this.ptype;
    }

    public virtual void Damage(float amt) {
        if (invTimer.elapsedTime > 5) {
            this.health -= amt;
            if (health <= 0) {
                Destroy(this.gameObject);
            }
        }
    }
}