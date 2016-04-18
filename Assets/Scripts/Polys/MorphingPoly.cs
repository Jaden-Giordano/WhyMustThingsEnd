using UnityEngine;
using System.Collections;

public enum MorphType {
    Shape = 0,
    Movement = 1,
    Rotation = 2,
    Projectiles = 3,
    Shields = 4,
    Health = 5
}

public class MorphingPoly : Poly {

    Timer timer;

    [SerializeField]
    protected float morphTime = 10f;

    [SerializeField]
    protected float morphChance = .5f;

    [SerializeField]
    public int morphCount = 0;

    [SerializeField]
    protected int reproduceAt = 10;

    [SerializeField]
    protected int[] morphTypeCount;

    protected override void init() {
        base.init();

        timer = new Timer();

        morphTypeCount = new int[6] { 0, 0, 0, 0, 0, 0 };
    }

    protected override void tick() {
        base.tick();

        // If ample space, alive long enough
        if (timer.elapsedTime > morphTime) {
            AttemptMorph();
        }
        if (morphCount > reproduceAt && Random.value > 0.5f) {
            AttemptReproduce();
        }
    }

    public virtual void AttemptReproduce() {
        int main = 0;
        for (int i = main; i < morphTypeCount.Length; i++) {
            if (morphTypeCount[i] > morphTypeCount[main]) {
                main = i;
            }
        }
        int sec = 0;
        if (sec == main) {
            sec++;
        }
        for (int i = 0; i < morphTypeCount.Length; i++) {
            if (i != main && morphTypeCount[i] > morphTypeCount[sec]) {
                sec = i;
            }
        }
        int tri = 0;
        for (int i = 0; i < morphTypeCount.Length; i++) {
            if (morphTypeCount[i] < morphTypeCount[sec]) {
                tri = i;
            }
        }
        for (int i = 0; i < morphTypeCount.Length; i++) {
            if (i != main && i != sec && morphTypeCount[i] > morphTypeCount[tri]) {
                tri = i;
            }
        }

        GameObject gm = Instantiate(Constants.morphingPoly);

        gm.transform.position = this.transform.position;

        MorphingPoly mp = gm.GetComponent<MorphingPoly>();

        for (int i = 0; i < morphCount/2; i++) {
            mp.Morph(main);
        }
        for (int i = 0; i < morphCount/4; i++) {
            mp.Morph(sec);
        }
        for (int i = 0; i < morphCount / 6; i++) {
            mp.Morph(tri);
        }
        for (int i = 0; i < morphCount / 8; i++) {
            mp.AttemptMorph();
        }

        mp.SetReproduceAt(Mathf.RoundToInt(this.reproduceAt * 1.7f));
        this.SetReproduceAt(Mathf.RoundToInt(this.reproduceAt * 1.5f));
    }

    public virtual void AttemptMorph() {
        if (Random.value > morphChance) {
            int r = Mathf.RoundToInt(Random.value * (int) MorphType.Health); // Shields dont work in this
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
            else if (r == (int)MorphType.Health) {
                Morph(MorphType.Health);
            }
            
        }
    }

    public virtual void Morph(int type) {
        if (type == (int)MorphType.Shape) {
            Morph(MorphType.Shape);
        }
        else if (type == (int)MorphType.Movement) {
            Morph(MorphType.Movement);
        }
        else if (type == (int)MorphType.Rotation) {
            Morph(MorphType.Rotation);
        }
        else if (type == (int)MorphType.Projectiles) {
            Morph(MorphType.Projectiles);
        }
        else if (type == (int)MorphType.Shields) {
            Morph(MorphType.Shields);
        }
        else if (type == (int)MorphType.Health) {
            Morph(MorphType.Health);
        }
    }

    public virtual void Morph(MorphType mtype) {
        switch (mtype) {
            case MorphType.Shape:
                int ra = Mathf.RoundToInt(Random.value);
                if (ra == 0) {
                    if (this.tag == "Player") {
                        ReduceSkillPointTime();
                    }
                    else {
                        this.morphTime -= .5f;
                    }
                }
                else {
                    switch (this.ptype) {
                        case PolyType.Hexagon:
                            this.ptype = PolyType.Octagon;
                            this.GetComponent<MeshFilter>().mesh = PolyTool.CreatePolygon(8, Color.black);
                            this.GetComponent<PolygonCollider2D>().points = PolyTool.CreateCollider(8);
                            break;
                        case PolyType.Pentagon:
                            this.ptype = PolyType.Hexagon;
                            this.GetComponent<MeshFilter>().mesh = PolyTool.CreatePolygon(6, Color.black);
                            this.GetComponent<PolygonCollider2D>().points = PolyTool.CreateCollider(6);
                            break;
                        case PolyType.Rectangle:
                            this.ptype = PolyType.Pentagon;
                            this.GetComponent<MeshFilter>().mesh = PolyTool.CreatePolygon(5, Color.black);
                            this.GetComponent<PolygonCollider2D>().points = PolyTool.CreateCollider(5);
                            break;
                        case PolyType.Triangle:
                            this.ptype = PolyType.Rectangle;
                            this.GetComponent<MeshFilter>().mesh = PolyTool.CreatePolygon(4, Color.black);
                            this.GetComponent<PolygonCollider2D>().points = PolyTool.CreateCollider(4);
                            break;
                    }
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
            case MorphType.Shields:
                Shield s = GetComponent<Shield>();
                if (s != null) {
                    s.Upgrade();
                }
                else {
                    this.gameObject.AddComponent<Shield>();
                }
                break;
            case MorphType.Health:
                float rat = this.health / this.maxHealth;
                this.maxHealth *= 1.15f;
                this.transform.localScale = new Vector3((this.maxHealth/10 < 8)?(this.maxHealth / 10):8, (this.maxHealth / 10 < 8) ? (this.maxHealth / 10) : 8, (this.maxHealth / 10 < 8) ? (this.maxHealth / 10) : 8);
                this.health = this.maxHealth * rat;
                this.health += this.maxHealth - this.health / 3;
                break;
        }
        timer.Reset();
        morphTypeCount[(int)mtype]++;
        morphCount++;
    }

    public virtual void SetReproduceAt(int amt) {
        this.reproduceAt = amt;
    }

    protected virtual void ReduceSkillPointTime() {

    }

}
