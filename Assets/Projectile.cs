using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
public class Projectile : MonoBehaviour {

    protected Vector3 direction;

    [SerializeField]
    protected float speed = 2;

	void Awake () {
        init();
	}

    protected virtual void init() {
        this.GetComponent<MeshFilter>().mesh = PolyTool.CreateOctagon();
        this.transform.localScale = new Vector3(.1f, .1f, 1);
        this.GetComponent<MeshFilter>().mesh.colors = PolyTool.SetColor(PolyType.Octagon, Color.black);
    }
	
	void Update () {
        tick();
	}

    protected virtual void tick() {
        this.transform.position = this.transform.position + (direction * speed * Time.deltaTime);
    }

    public virtual void SetDirection(Vector3 dir) {
        this.direction = dir;
    } 

}
