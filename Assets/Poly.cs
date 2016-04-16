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
[RequireComponent(typeof(MeshCollider))]
public class Poly : MonoBehaviour {

    protected PolyType ptype;

	void Awake() {
        init();
    }

    protected virtual void init() {
        this.GetComponent<MeshFilter>().mesh = PolyTool.CreateTriangle();
        this.GetComponent<MeshCollider>().sharedMesh = this.GetComponent<MeshFilter>().mesh;
        this.GetComponent<MeshRenderer>().materials[0] = Constants.vertexColor;
        this.ptype = PolyType.Triangle;
    }

    void Update() {
        tick();
    }

    protected virtual void tick() {

    }

    public virtual PolyType GetPolyType() {
        return this.ptype;
    }
}