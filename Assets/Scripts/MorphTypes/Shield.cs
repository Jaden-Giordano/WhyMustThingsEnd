using UnityEngine;
using System.Collections.Generic;

public class Shield : MonoBehaviour {

    Timer regen;

    protected float regenTime = 2f;

    Timer rotate;

    [SerializeField]
    protected int amountOfShields;

	void Awake () {
        init();
	}

    protected virtual void init() {
        amountOfShields = 2;
        regen = new Timer();
        AddShield(0);
        AddShield(1);

        rotate = new Timer();
    }
	
	void Update () {
        tick();
	}

    protected virtual void tick() {
        if (this.transform.childCount < amountOfShields && regen.elapsedTime > regenTime) {
            AddShield(this.transform.childCount);
            regen.Reset();
        }
        ShieldProjectile[] l = this.GetComponentsInChildren<ShieldProjectile>();
        for (int i = 0; i < l.Length; i++) {
            l[i].transform.localPosition = new Vector3(2 * Mathf.Cos((float)rotate.elapsedTime + (i * (Mathf.Deg2Rad * (360/amountOfShields)))), 2 * Mathf.Sin((float)rotate.elapsedTime + (i * (Mathf.Deg2Rad * (360 / amountOfShields)))));
        }
    }

    public virtual void AddShield(int i) {
        GameObject proj = new GameObject();
        proj.AddComponent<ShieldProjectile>();
        proj.transform.position = this.transform.position + new Vector3(Mathf.Cos(Mathf.Deg2Rad * (i * (360/amountOfShields))), Mathf.Sin(Mathf.Deg2Rad * (i * (360/amountOfShields))));
        Projectile p = proj.GetComponent<Projectile>();
        proj.transform.parent = this.transform;
        proj.transform.localScale = this.transform.localScale / 10;
        p.SetOwner(this.gameObject);
    }

    public virtual void Upgrade() {
        int r = Mathf.RoundToInt(Random.value);
        if (r == 0) {
            this.amountOfShields++;
        }
        else {
            this.regenTime *= 0.9f;
            if (this.regenTime < 0.2f) {
                this.regenTime = 0.2f;
            }
        }
    }
}
