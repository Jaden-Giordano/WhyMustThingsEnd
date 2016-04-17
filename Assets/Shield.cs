using UnityEngine;
using System.Collections.Generic;

public class Shield : MonoBehaviour {

    Timer regen;

    protected float regenTime = 2f;

    Timer rotate;

    [SerializeField]
    protected int amountOfShields;
    List<Projectile> shields;

	void Awake () {
        init();
	}

    protected virtual void init() {
        amountOfShields = 2;
        regen = new Timer();
        shields = new List<Projectile>();
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
        proj.transform.position = this.transform.position + new Vector3(Mathf.Cos(Mathf.Deg2Rad * (i * (amountOfShields/360))), Mathf.Sin(Mathf.Deg2Rad * (i * (amountOfShields / 360))));
        Projectile p = proj.GetComponent<Projectile>();
        proj.transform.parent = this.transform;
        p.SetOwner(this.gameObject);
        this.shields.Add(p);
    }

    public virtual void Upgrade() {
        this.amountOfShields++;
    }
}
