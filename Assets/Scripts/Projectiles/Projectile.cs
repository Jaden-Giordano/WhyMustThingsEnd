using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(PolygonCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour {

    protected Vector3 direction;

    protected Timer timer;

    protected GameObject owner;

    [SerializeField]
    public float damage = 1f;

    [SerializeField]
    public float life = 6f;

    [SerializeField]
    public float speed = 2;

	void Awake () {
        init();
	}

    protected virtual void init() {
        this.timer = new Timer();

        this.GetComponent<MeshFilter>().mesh = PolyTool.CreateOctagon();
        this.GetComponent<PolygonCollider2D>().points = PolyTool.CreateOctagonCollider();
        this.transform.localScale = new Vector3(.1f, .1f, 1);
        this.GetComponent<MeshFilter>().mesh.colors = PolyTool.SetColor(PolyType.Octagon, Color.black);
        this.GetComponent<MeshRenderer>().sharedMaterial = Constants.vertexColorMat;

        this.GetComponent<Rigidbody2D>().gravityScale = 0;
        this.GetComponent<Rigidbody2D>().mass = 0.00001f;
        this.GetComponent<Rigidbody2D>().freezeRotation = true;
        this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;

        this.tag = "Projectile";
    }
	
	void Update () {
        tick();
    }

    protected virtual void tick() {
        this.transform.position = this.transform.position + (direction * speed * Time.deltaTime);
        if (this.timer.elapsedTime > this.life) {
            Destroy(this.gameObject);
        }
    }

    public virtual void SetDirection(Vector3 dir) {
        this.direction = dir;
    } 

    public virtual void SetShader(Shader shader) {
        this.GetComponent<Material>().shader = shader;
    }

    public virtual void SetOwner(GameObject o) {
        this.owner = o;
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject != this.owner) {
            if (col.gameObject.tag == "Projectile" && timer.elapsedTime > 0.2f) {
                if (col.gameObject.GetComponent<Projectile>().owner != this.owner && col.gameObject.transform.parent != this.owner && col.gameObject.transform.parent != this.transform.parent) {
                    Destroy(col.gameObject);
                    Destroy(this.gameObject);
                }
            }
            else if (col.gameObject.tag == "Poly" || col.gameObject.tag == "Player") {
                if (col.gameObject.GetComponent<Poly>().health-this.damage < 0 && this.owner.tag == "Player") {
                    this.owner.GetComponent<Player>().AddSkillPoints(col.gameObject.GetComponent<MorphingPoly>().morphCount / 3);
                }
                col.gameObject.GetComponent<Poly>().Damage(this.damage);
                Destroy(this.gameObject);
            }
        }
    }

}
