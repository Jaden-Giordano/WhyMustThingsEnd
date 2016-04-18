using UnityEngine;
using System.Collections;

public enum UpgradeType {
    ProjectileSpeed = 0,
    ProjectileDamage = 1,
    LauncherType = 2,
    BurstAmount = 3
}

public enum LauncherType {
    Single = 1,
    Spread = 2,
}

public class ProjectileLauncher : MonoBehaviour {

    protected Timer timer;
    protected Timer burstTimer;

    [SerializeField]
    protected float launchCooldown = 4f;

    [SerializeField]
    protected float burstCooldown = .3f;
    private float burstCount = 1;
    private bool burst = false;
    protected int burstAmount = 1;

    [SerializeField]
    protected LauncherType ltype;

    protected float projectileSpeed;
    protected float projectileDamage;

	void Awake () {
        init();
	}

    protected virtual void init() {
        timer = new Timer();
        burstTimer = new Timer();
        ltype = LauncherType.Single;
        projectileSpeed = 1f;
        projectileDamage = 1f;
    }
	
	void Update () {
        tick();
	}

    protected virtual void tick() {
        if (this.gameObject.tag == "Player") {
            if (Input.GetKey(KeyCode.Space) && timer.elapsedTime > launchCooldown) {
                timer.Reset();
                LaunchProjectiles();
                burst = true;
                burstCount = 1;
                burstTimer.Reset();
            }
        }
        else {
            if (timer.elapsedTime > launchCooldown) {
                timer.Reset();
                LaunchProjectiles();
                burst = true;
                burstCount = 1;
                burstTimer.Reset();
            }
        }
        if (burst) {
            if (burstCount >= burstAmount) {
                burst = false;
            }
            else if (burstTimer.elapsedTime > burstCooldown) {
                LaunchProjectiles();
                burstCount++;
                burstTimer.Reset();
            }
        }
    }

    public virtual void Upgrade() {
        int r = Mathf.RoundToInt(Random.value * 2);
        switch (r) {
            case (int)UpgradeType.ProjectileSpeed:
                this.projectileSpeed *= 1.25f;
                break;
            case (int)UpgradeType.ProjectileDamage:
                this.projectileDamage *= 1.25f;
                break;
            case (int)UpgradeType.LauncherType:
                this.ltype = LauncherType.Spread;
                break;
            case (int)UpgradeType.BurstAmount:
                this.burstAmount++;
                break;
        }
    }

    public virtual void Launch(Vector3 dir) {
        GameObject proj = new GameObject();
        proj.AddComponent<Projectile>();
        proj.transform.position = this.transform.position;
        Projectile p = proj.GetComponent<Projectile>();
        p.SetOwner(this.gameObject);
        p.SetDirection(dir);
        p.speed = projectileSpeed;
        p.damage = projectileDamage;
        if (this.transform.localScale.x < 10) {
            proj.transform.localScale = this.transform.localScale/10;
        }
        else {
            proj.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    public virtual void LaunchProjectiles() {
        float up = this.transform.rotation.eulerAngles.z+90;
        switch (GetComponent<Poly>().GetPolyType()) {
            case PolyType.Triangle:
                if (ltype == LauncherType.Spread) {
                    for (int i = -1; i < 2; i++) {
                        Vector3 d1 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 60 + (5*i))), Mathf.Sin(Mathf.Deg2Rad * (up + 60 + (5 * i))));
                        Launch(d1);

                        Vector3 d2 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 180 + (5 * i))), Mathf.Sin(Mathf.Deg2Rad * (up + 180 + (5 * i))));
                        Launch(d2);

                        Vector3 d3 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 300 + (5 * i))), Mathf.Sin(Mathf.Deg2Rad * (up + 300 + (5 * i))));
                        Launch(d3);
                    }
                }
                else {
                    Vector3 d1 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 60)), Mathf.Sin(Mathf.Deg2Rad * (up + 60)));
                    Launch(d1);

                    Vector3 d2 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 180)), Mathf.Sin(Mathf.Deg2Rad * (up + 180)));
                    Launch(d2);

                    Vector3 d3 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 300)), Mathf.Sin(Mathf.Deg2Rad * (up + 300)));
                    Launch(d3);
                }
                break;
            case PolyType.Rectangle:
                if (ltype == LauncherType.Spread) {
                    for (int i = -1; i < 2; i++) {
                        Vector3 d1 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 0 + (5 * i))), Mathf.Sin(Mathf.Deg2Rad * (up + 0 + (5 * i))));
                        Launch(d1);

                        Vector3 d2 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 90 + (5 * i))), Mathf.Sin(Mathf.Deg2Rad * (up + 90 + (5 * i))));
                        Launch(d2);

                        Vector3 d3 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 180 + (5 * i))), Mathf.Sin(Mathf.Deg2Rad * (up + 180 + (5 * i))));
                        Launch(d3);

                        Vector3 d4 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 270 + (5 * i))), Mathf.Sin(Mathf.Deg2Rad * (up + 270 + (5 * i))));
                        Launch(d4);
                    }
                }
                else {
                    Vector3 d1 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 0)), Mathf.Sin(Mathf.Deg2Rad * (up + 0)));
                    Launch(d1);

                    Vector3 d2 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 90)), Mathf.Sin(Mathf.Deg2Rad * (up + 90)));
                    Launch(d2);

                    Vector3 d3 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 180)), Mathf.Sin(Mathf.Deg2Rad * (up + 180)));
                    Launch(d3);

                    Vector3 d4 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 270)), Mathf.Sin(Mathf.Deg2Rad * (up + 270)));
                    Launch(d4);
                }

                break;
            case PolyType.Pentagon:
                if (ltype == LauncherType.Spread) {
                    for (int i = -1; i < 2; i++) {
                        Vector3 d1 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 36 + (5 * i))), Mathf.Sin(Mathf.Deg2Rad * (up + 36 + (5 * i))));
                        Launch(d1);

                        Vector3 d2 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 108 + (5 * i))), Mathf.Sin(Mathf.Deg2Rad * (up + 108 + (5 * i))));
                        Launch(d2);

                        Vector3 d3 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 180 + (5 * i))), Mathf.Sin(Mathf.Deg2Rad * (up + 180 + (5 * i))));
                        Launch(d3);

                        Vector3 d4 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 252 + (5 * i))), Mathf.Sin(Mathf.Deg2Rad * (up + 252 + (5 * i))));
                        Launch(d4);

                        Vector3 d5 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 324 + (5 * i))), Mathf.Sin(Mathf.Deg2Rad * (up + 324 + (5 * i))));
                        Launch(d5);
                    }
                }
                else {
                    Vector3 d1 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 36)), Mathf.Sin(Mathf.Deg2Rad * (up + 36)));
                    Launch(d1);

                    Vector3 d2 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 108)), Mathf.Sin(Mathf.Deg2Rad * (up + 108)));
                    Launch(d2);

                    Vector3 d3 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 180)), Mathf.Sin(Mathf.Deg2Rad * (up + 180)));
                    Launch(d3);

                    Vector3 d4 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 252)), Mathf.Sin(Mathf.Deg2Rad * (up + 252)));
                    Launch(d4);

                    Vector3 d5 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 324)), Mathf.Sin(Mathf.Deg2Rad * (up + 324)));
                    Launch(d5);
                }
                break;
            case PolyType.Hexagon:
                if (ltype == LauncherType.Spread) {
                    for (int i = -1; i < 2; i++) {
                        Vector3 d1 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 30 + (5 * i))), Mathf.Sin(Mathf.Deg2Rad * (up + 30 + (5 * i))));
                        Launch(d1);

                        Vector3 d2 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 90 + (5 * i))), Mathf.Sin(Mathf.Deg2Rad * (up + 90 + (5 * i))));
                        Launch(d2);

                        Vector3 d3 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 150 + (5 * i))), Mathf.Sin(Mathf.Deg2Rad * (up + 150 + (5 * i))));
                        Launch(d3);

                        Vector3 d4 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 210 + (5 * i))), Mathf.Sin(Mathf.Deg2Rad * (up + 210 + (5 * i))));
                        Launch(d4);

                        Vector3 d5 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 270 + (5 * i))), Mathf.Sin(Mathf.Deg2Rad * (up + 270 + (5 * i))));
                        Launch(d5);

                        Vector3 d6 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 330 + (5 * i))), Mathf.Sin(Mathf.Deg2Rad * (up + 330 + (5 * i))));
                        Launch(d6);
                    }
                }
                else {
                    Vector3 d1 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 30)), Mathf.Sin(Mathf.Deg2Rad * (up + 30)));
                    Launch(d1);

                    Vector3 d2 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 90)), Mathf.Sin(Mathf.Deg2Rad * (up + 90)));
                    Launch(d2);

                    Vector3 d3 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 150)), Mathf.Sin(Mathf.Deg2Rad * (up + 150)));
                    Launch(d3);

                    Vector3 d4 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 210)), Mathf.Sin(Mathf.Deg2Rad * (up + 210)));
                    Launch(d4);

                    Vector3 d5 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 270)), Mathf.Sin(Mathf.Deg2Rad * (up + 270)));
                    Launch(d5);

                    Vector3 d6 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 330)), Mathf.Sin(Mathf.Deg2Rad * (up + 330)));
                    Launch(d6);
                }

                break;
            case PolyType.Octagon:
                if (ltype == LauncherType.Spread) {
                    for (int i = -1; i < 2; i++) {
                        Vector3 d1 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 22.5f + (5 * i))), Mathf.Sin(Mathf.Deg2Rad * (up + 22.5f + (5 * i))));
                        Launch(d1);

                        Vector3 d2 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 67.5f + (5 * i))), Mathf.Sin(Mathf.Deg2Rad * (up + 67.5f + (5 * i))));
                        Launch(d2);

                        Vector3 d3 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 112.5f + (5 * i))), Mathf.Sin(Mathf.Deg2Rad * (up + 112.5f + (5 * i))));
                        Launch(d3);

                        Vector3 d4 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 157.5f + (5 * i))), Mathf.Sin(Mathf.Deg2Rad * (up + 157.5f + (5 * i))));
                        Launch(d4);

                        Vector3 d5 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 202.5f + (5 * i))), Mathf.Sin(Mathf.Deg2Rad * (up + 202.5f + (5 * i))));
                        Launch(d5);

                        Vector3 d6 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 247.5f + (5 * i))), Mathf.Sin(Mathf.Deg2Rad * (up + 247.5f + (5 * i))));
                        Launch(d6);

                        Vector3 d7 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 292.5f + (5 * i))), Mathf.Sin(Mathf.Deg2Rad * (up + 292.5f + (5 * i))));
                        Launch(d7);

                        Vector3 d8 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 337.5f + (5 * i))), Mathf.Sin(Mathf.Deg2Rad * (up + 337.5f + (5 * i))));
                        Launch(d8);
                    }
                }
                else {
                    Vector3 d1 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 22.5f)), Mathf.Sin(Mathf.Deg2Rad * (up + 22.5f)));
                    Launch(d1);

                    Vector3 d2 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 67.5f)), Mathf.Sin(Mathf.Deg2Rad * (up + 67.5f)));
                    Launch(d2);

                    Vector3 d3 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 112.5f)), Mathf.Sin(Mathf.Deg2Rad * (up + 112.5f)));
                    Launch(d3);

                    Vector3 d4 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 157.5f)), Mathf.Sin(Mathf.Deg2Rad * (up + 157.5f)));
                    Launch(d4);

                    Vector3 d5 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 202.5f)), Mathf.Sin(Mathf.Deg2Rad * (up + 202.5f)));
                    Launch(d5);

                    Vector3 d6 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 247.5f)), Mathf.Sin(Mathf.Deg2Rad * (up + 247.5f)));
                    Launch(d6);

                    Vector3 d7 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 292.5f)), Mathf.Sin(Mathf.Deg2Rad * (up + 292.5f)));
                    Launch(d7);

                    Vector3 d8 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 337.5f)), Mathf.Sin(Mathf.Deg2Rad * (up + 337.5f)));
                    Launch(d8);
                }

                break;
        }
    }

}
