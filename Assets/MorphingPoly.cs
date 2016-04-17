using UnityEngine;
using System.Collections;

public enum MorphType {
    Shape = 0,
    Movement = 1,
    Rotation = 2,
    Projectiles = 3,
    Shields = 4
}

public class MorphingPoly : Poly {

    Timer timer;

    [SerializeField]
    protected float morphTime = 10f;

    [SerializeField]
    protected float morphChance = .5f;

    protected override void init() {
        base.init();

        timer = new Timer();
    }

    protected override void tick() {
        base.tick();

        // If ample space, alive long enough
        if (timer.elapsedTime > morphTime) {
            AttemptMorph();
        }
    }

    public virtual void AttemptMorph() {
        if (Random.value > morphChance) {
            int r = Mathf.RoundToInt(Random.value * 3); // Shields dont work in this
            if (r == (int)MorphType.Shape) {
                Morph(MorphType.Shape);
            }
            else if (r == (int)MorphType.Movement) {
                Morph(MorphType.Movement);
            }
            else if (r == (int)MorphType.Rotation) {
                Morph(MorphType.Rotation);
            }
            else if (r == (int)MorphType.Projectiles) {
                Morph(MorphType.Projectiles);
            }
            else if (r == (int)MorphType.Shields) {
                Morph(MorphType.Shields);
            }
        }
    }

    public virtual void Morph(MorphType mtype) {
        switch (mtype) {
            case MorphType.Shape:
                switch (this.ptype) {
                    case PolyType.Hexagon:
                        this.ptype = PolyType.Octagon;
                        this.GetComponent<MeshFilter>().mesh = PolyTool.CreateOctagon();
                        this.GetComponent<MeshCollider>().sharedMesh = this.GetComponent<MeshFilter>().mesh;
                        break;
                    case PolyType.Pentagon:
                        this.ptype = PolyType.Hexagon;
                        this.GetComponent<MeshFilter>().mesh = PolyTool.CreateHexagon();
                        this.GetComponent<MeshCollider>().sharedMesh = this.GetComponent<MeshFilter>().mesh;
                        break;
                    case PolyType.Rectangle:
                        this.ptype = PolyType.Pentagon;
                        this.GetComponent<MeshFilter>().mesh = PolyTool.CreatePentagon();
                        this.GetComponent<MeshCollider>().sharedMesh = this.GetComponent<MeshFilter>().mesh;
                        break;

                    case PolyType.Triangle:
                        this.ptype = PolyType.Rectangle;
                        this.GetComponent<MeshFilter>().mesh = PolyTool.CreateSquare();
                        this.GetComponent<MeshCollider>().sharedMesh = this.GetComponent<MeshFilter>().mesh;
                        break;
                }
                break;
            case MorphType.Projectiles:
                ProjectileLauncher pl = GetComponent<ProjectileLauncher>();
                if (pl != null) {
                    pl.Upgrade();
                }
                else {
                    this.gameObject.AddComponent<ProjectileLauncher>();
                }
                break;
            case MorphType.Rotation:
                Rotator rot = GetComponent<Rotator>();
                if (rot != null) {
                    rot.Upgrade();
                }
                else {
                    this.gameObject.AddComponent<Rotator>();
                }
                break;
            case MorphType.Movement:
                Mover m = GetComponent<Mover>();
                if (m != null) {
                    m.Upgrade();
                }
                else {
                    this.gameObject.AddComponent<Mover>();
                }
                break;
        }
        timer.Reset();
    }

}
