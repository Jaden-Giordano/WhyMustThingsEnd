using UnityEngine;
using System.Collections.Generic;

public class Shield : MonoBehaviour {

    Timer regen;

    protected float regenTime = 2f;

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
    }
	
	void Update () {
        tick();
	}

    protected virtual void tick() {
        if (this.transform.childCount < amountOfShields && regen.elapsedTime > regenTime) {
            AddShield(this.transform.childCount - 1);
            regen.Reset();
        }
    }

    public virtual void AddShield(int i) {
        GameObject proj = new GameObject();
        proj.AddComponent<ShieldProjectile>();
        proj.transform.position = this.transform.position + new Vector3(Mathf.Cos(Mathf.Deg2Rad * (i * (360 / amountOfShields))), Mathf.Sin(Mathf.Deg2Rad * (i * (360 / amountOfShields))));
        Projectile p = proj.GetComponent<Projectile>();
        proj.transform.parent = this.transform;
        this.shields.Add(p);
    }

    public virtual void Upgrade() {
        this.amountOfShields++;
    }
}
