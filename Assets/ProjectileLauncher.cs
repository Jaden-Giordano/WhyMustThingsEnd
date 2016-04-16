using UnityEngine;
using System.Collections;

public enum LauncherType {
    Single = 1,
    Double = 2,
    Triple = 3,
    Spread = 1
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

    protected LauncherType ltype;

	void Awake () {
        init();
	}

    protected virtual void init() {
        timer = new Timer();
        burstTimer = new Timer();
        ltype = LauncherType.Single;
    }
	
	void Update () {
        tick();
	}

    protected virtual void tick() {
        if (timer.elapsedTime > launchCooldown) {
            timer.Reset();
            LaunchProjectile();
            burst = true;
            burstCount = 1;
            burstTimer.Reset();
        }
        if (burst) {
            if (burstCount >= (int)ltype) {
                burst = false;
            }
            else if (burstTimer.elapsedTime > burstCooldown) {
                LaunchProjectile();
                burstCount++;
                burstTimer.Reset();
            }
        }
    }

    public virtual void Upgrade() {
        switch (ltype) {
            case LauncherType.Triple:
                this.ltype = LauncherType.Spread;
                break;
            case LauncherType.Double:
                this.ltype = LauncherType.Triple;
                break;
            case LauncherType.Single:
                this.ltype = LauncherType.Double;
                break;
        }
    }

    public virtual void LaunchProjectile() {
        float up = this.transform.rotation.eulerAngles.z+90;
        switch (GetComponent<Poly>().GetPolyType()) {
            case PolyType.Triangle:
                if (ltype == LauncherType.Spread) {
                    for (int i = -1; i < 2; i++) {
                        Vector3 d1 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 60 + (5*i))), Mathf.Sin(Mathf.Deg2Rad * (up + 60 + (5 * i))));
                        GameObject proj = new GameObject();
                        proj.AddComponent<Projectile>();
                        proj.transform.position = this.transform.position;
                        proj.GetComponent<Projectile>().SetDirection(d1);

                        Vector3 d2 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 180 + (5 * i))), Mathf.Sin(Mathf.Deg2Rad * (up + 180 + (5 * i))));
                        GameObject proj1 = new GameObject();
                        proj1.AddComponent<Projectile>();
                        proj1.transform.position = this.transform.position;
                        proj1.GetComponent<Projectile>().SetDirection(d2);


                        Vector3 d3 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 300 + (5 * i))), Mathf.Sin(Mathf.Deg2Rad * (up + 300 + (5 * i))));
                        GameObject proj2 = new GameObject();
                        proj2.AddComponent<Projectile>();
                        proj2.transform.position = this.transform.position;
                        proj2.GetComponent<Projectile>().SetDirection(d3);
                    }
                }
                else {
                    Vector3 d1 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 60)), Mathf.Sin(Mathf.Deg2Rad * (up + 60)));
                    GameObject proj = new GameObject();
                    proj.AddComponent<Projectile>();
                    proj.transform.position = this.transform.position;
                    proj.GetComponent<Projectile>().SetDirection(d1);

                    Vector3 d2 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 180)), Mathf.Sin(Mathf.Deg2Rad * (up + 180)));
                    GameObject proj1 = new GameObject();
                    proj1.AddComponent<Projectile>();
                    proj1.transform.position = this.transform.position;
                    proj1.GetComponent<Projectile>().SetDirection(d2);


                    Vector3 d3 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 300)), Mathf.Sin(Mathf.Deg2Rad * (up + 300)));
                    GameObject proj2 = new GameObject();
                    proj2.AddComponent<Projectile>();
                    proj2.transform.position = this.transform.position;
                    proj2.GetComponent<Projectile>().SetDirection(d3);
                }
                break;
            case PolyType.Rectangle:
                if (ltype == LauncherType.Spread) {
                    for (int i = -1; i < 2; i++) {
                        Vector3 d1 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 0 + (5 * i))), Mathf.Sin(Mathf.Deg2Rad * (up + 0 + (5 * i))));
                        GameObject proj = new GameObject();
                        proj.AddComponent<Projectile>();
                        proj.transform.position = this.transform.position;
                        proj.GetComponent<Projectile>().SetDirection(d1);

                        Vector3 d2 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 90 + (5 * i))), Mathf.Sin(Mathf.Deg2Rad * (up + 90 + (5 * i))));
                        GameObject proj1 = new GameObject();
                        proj1.AddComponent<Projectile>();
                        proj1.transform.position = this.transform.position;
                        proj1.GetComponent<Projectile>().SetDirection(d2);

                        Vector3 d3 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 180 + (5 * i))), Mathf.Sin(Mathf.Deg2Rad * (up + 180 + (5 * i))));
                        GameObject proj2 = new GameObject();
                        proj2.AddComponent<Projectile>();
                        proj2.transform.position = this.transform.position;
                        proj2.GetComponent<Projectile>().SetDirection(d3);

                        Vector3 d4 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 270 + (5 * i))), Mathf.Sin(Mathf.Deg2Rad * (up + 270 + (5 * i))));
                        GameObject proj3 = new GameObject();
                        proj3.AddComponent<Projectile>();
                        proj3.transform.position = this.transform.position;
                        proj3.GetComponent<Projectile>().SetDirection(d4);
                    }
                }
                else {
                    Vector3 d1 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 0)), Mathf.Sin(Mathf.Deg2Rad * (up + 0)));
                    GameObject proj = new GameObject();
                    proj.AddComponent<Projectile>();
                    proj.transform.position = this.transform.position;
                    proj.GetComponent<Projectile>().SetDirection(d1);

                    Vector3 d2 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 90)), Mathf.Sin(Mathf.Deg2Rad * (up + 90)));
                    GameObject proj1 = new GameObject();
                    proj1.AddComponent<Projectile>();
                    proj1.transform.position = this.transform.position;
                    proj1.GetComponent<Projectile>().SetDirection(d2);

                    Vector3 d3 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 180)), Mathf.Sin(Mathf.Deg2Rad * (up + 180)));
                    GameObject proj2 = new GameObject();
                    proj2.AddComponent<Projectile>();
                    proj2.transform.position = this.transform.position;
                    proj2.GetComponent<Projectile>().SetDirection(d3);

                    Vector3 d4 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 270)), Mathf.Sin(Mathf.Deg2Rad * (up + 270)));
                    GameObject proj3 = new GameObject();
                    proj3.AddComponent<Projectile>();
                    proj3.transform.position = this.transform.position;
                    proj3.GetComponent<Projectile>().SetDirection(d4);
                }

                break;
            case PolyType.Pentagon:
                if (ltype == LauncherType.Spread) {
                    for (int i = -1; i < 2; i++) {
                        Vector3 d1 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 36 + (5 * i))), Mathf.Sin(Mathf.Deg2Rad * (up + 36 + (5 * i))));
                        GameObject proj = new GameObject();
                        proj.AddComponent<Projectile>();
                        proj.transform.position = this.transform.position;
                        proj.GetComponent<Projectile>().SetDirection(d1);

                        Vector3 d2 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 108 + (5 * i))), Mathf.Sin(Mathf.Deg2Rad * (up + 108 + (5 * i))));
                        GameObject proj1 = new GameObject();
                        proj1.AddComponent<Projectile>();
                        proj1.transform.position = this.transform.position;
                        proj1.GetComponent<Projectile>().SetDirection(d2);

                        Vector3 d3 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 180 + (5 * i))), Mathf.Sin(Mathf.Deg2Rad * (up + 180 + (5 * i))));
                        GameObject proj2 = new GameObject();
                        proj2.AddComponent<Projectile>();
                        proj2.transform.position = this.transform.position;
                        proj2.GetComponent<Projectile>().SetDirection(d3);

                        Vector3 d4 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 252 + (5 * i))), Mathf.Sin(Mathf.Deg2Rad * (up + 252 + (5 * i))));
                        GameObject proj3 = new GameObject();
                        proj3.AddComponent<Projectile>();
                        proj3.transform.position = this.transform.position;
                        proj3.GetComponent<Projectile>().SetDirection(d4);

                        Vector3 d5 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 324 + (5 * i))), Mathf.Sin(Mathf.Deg2Rad * (up + 324 + (5 * i))));
                        GameObject proj4 = new GameObject();
                        proj4.AddComponent<Projectile>();
                        proj4.transform.position = this.transform.position;
                        proj4.GetComponent<Projectile>().SetDirection(d5);
                    }
                }
                else {
                    Vector3 d1 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 36)), Mathf.Sin(Mathf.Deg2Rad * (up + 36)));
                    GameObject proj = new GameObject();
                    proj.AddComponent<Projectile>();
                    proj.transform.position = this.transform.position;
                    proj.GetComponent<Projectile>().SetDirection(d1);

                    Vector3 d2 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 108)), Mathf.Sin(Mathf.Deg2Rad * (up + 108)));
                    GameObject proj1 = new GameObject();
                    proj1.AddComponent<Projectile>();
                    proj1.transform.position = this.transform.position;
                    proj1.GetComponent<Projectile>().SetDirection(d2);

                    Vector3 d3 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 180)), Mathf.Sin(Mathf.Deg2Rad * (up + 180)));
                    GameObject proj2 = new GameObject();
                    proj2.AddComponent<Projectile>();
                    proj2.transform.position = this.transform.position;
                    proj2.GetComponent<Projectile>().SetDirection(d3);

                    Vector3 d4 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 252)), Mathf.Sin(Mathf.Deg2Rad * (up + 252)));
                    GameObject proj3 = new GameObject();
                    proj3.AddComponent<Projectile>();
                    proj3.transform.position = this.transform.position;
                    proj3.GetComponent<Projectile>().SetDirection(d4);

                    Vector3 d5 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 324)), Mathf.Sin(Mathf.Deg2Rad * (up + 324)));
                    GameObject proj4 = new GameObject();
                    proj4.AddComponent<Projectile>();
                    proj4.transform.position = this.transform.position;
                    proj4.GetComponent<Projectile>().SetDirection(d5);
                }
                break;
            case PolyType.Hexagon:
                if (ltype == LauncherType.Spread) {
                    for (int i = -1; i < 2; i++) {
                        Vector3 d1 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 30 + (5 * i))), Mathf.Sin(Mathf.Deg2Rad * (up + 30 + (5 * i))));
                        GameObject proj = new GameObject();
                        proj.AddComponent<Projectile>();
                        proj.transform.position = this.transform.position;
                        proj.GetComponent<Projectile>().SetDirection(d1);

                        Vector3 d2 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 90 + (5 * i))), Mathf.Sin(Mathf.Deg2Rad * (up + 90 + (5 * i))));
                        GameObject proj1 = new GameObject();
                        proj1.AddComponent<Projectile>();
                        proj1.transform.position = this.transform.position;
                        proj1.GetComponent<Projectile>().SetDirection(d2);

                        Vector3 d3 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 150 + (5 * i))), Mathf.Sin(Mathf.Deg2Rad * (up + 150 + (5 * i))));
                        GameObject proj2 = new GameObject();
                        proj2.AddComponent<Projectile>();
                        proj2.transform.position = this.transform.position;
                        proj2.GetComponent<Projectile>().SetDirection(d3);

                        Vector3 d4 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 210 + (5 * i))), Mathf.Sin(Mathf.Deg2Rad * (up + 210 + (5 * i))));
                        GameObject proj3 = new GameObject();
                        proj3.AddComponent<Projectile>();
                        proj3.transform.position = this.transform.position;
                        proj3.GetComponent<Projectile>().SetDirection(d4);

                        Vector3 d5 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 270 + (5 * i))), Mathf.Sin(Mathf.Deg2Rad * (up + 270 + (5 * i))));
                        GameObject proj4 = new GameObject();
                        proj4.AddComponent<Projectile>();
                        proj4.transform.position = this.transform.position;
                        proj4.GetComponent<Projectile>().SetDirection(d5);

                        Vector3 d6 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 330 + (5 * i))), Mathf.Sin(Mathf.Deg2Rad * (up + 330 + (5 * i))));
                        GameObject proj5 = new GameObject();
                        proj5.AddComponent<Projectile>();
                        proj5.transform.position = this.transform.position;
                        proj5.GetComponent<Projectile>().SetDirection(d6);
                    }
                }
                else {
                    Vector3 d1 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 30)), Mathf.Sin(Mathf.Deg2Rad * (up + 30)));
                    GameObject proj = new GameObject();
                    proj.AddComponent<Projectile>();
                    proj.transform.position = this.transform.position;
                    proj.GetComponent<Projectile>().SetDirection(d1);

                    Vector3 d2 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 90)), Mathf.Sin(Mathf.Deg2Rad * (up + 90)));
                    GameObject proj1 = new GameObject();
                    proj1.AddComponent<Projectile>();
                    proj1.transform.position = this.transform.position;
                    proj1.GetComponent<Projectile>().SetDirection(d2);

                    Vector3 d3 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 150)), Mathf.Sin(Mathf.Deg2Rad * (up + 150)));
                    GameObject proj2 = new GameObject();
                    proj2.AddComponent<Projectile>();
                    proj2.transform.position = this.transform.position;
                    proj2.GetComponent<Projectile>().SetDirection(d3);

                    Vector3 d4 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 210)), Mathf.Sin(Mathf.Deg2Rad * (up + 210)));
                    GameObject proj3 = new GameObject();
                    proj3.AddComponent<Projectile>();
                    proj3.transform.position = this.transform.position;
                    proj3.GetComponent<Projectile>().SetDirection(d4);

                    Vector3 d5 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 270)), Mathf.Sin(Mathf.Deg2Rad * (up + 270)));
                    GameObject proj4 = new GameObject();
                    proj4.AddComponent<Projectile>();
                    proj4.transform.position = this.transform.position;
                    proj4.GetComponent<Projectile>().SetDirection(d5);

                    Vector3 d6 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 330)), Mathf.Sin(Mathf.Deg2Rad * (up + 330)));
                    GameObject proj5 = new GameObject();
                    proj5.AddComponent<Projectile>();
                    proj5.transform.position = this.transform.position;
                    proj5.GetComponent<Projectile>().SetDirection(d6);
                }

                break;
            case PolyType.Octagon:
                if (ltype == LauncherType.Spread) {
                    for (int i = -1; i < 2; i++) {
                        Vector3 d1 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 22.5f + (5 * i))), Mathf.Sin(Mathf.Deg2Rad * (up + 22.5f + (5 * i))));
                        GameObject proj = new GameObject();
                        proj.AddComponent<Projectile>();
                        proj.transform.position = this.transform.position;
                        proj.GetComponent<Projectile>().SetDirection(d1);

                        Vector3 d2 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 67.5f + (5 * i))), Mathf.Sin(Mathf.Deg2Rad * (up + 67.5f + (5 * i))));
                        GameObject proj1 = new GameObject();
                        proj1.AddComponent<Projectile>();
                        proj1.transform.position = this.transform.position;
                        proj1.GetComponent<Projectile>().SetDirection(d2);

                        Vector3 d3 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 112.5f + (5 * i))), Mathf.Sin(Mathf.Deg2Rad * (up + 112.5f + (5 * i))));
                        GameObject proj2 = new GameObject();
                        proj2.AddComponent<Projectile>();
                        proj2.transform.position = this.transform.position;
                        proj2.GetComponent<Projectile>().SetDirection(d3);

                        Vector3 d4 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 157.5f + (5 * i))), Mathf.Sin(Mathf.Deg2Rad * (up + 157.5f + (5 * i))));
                        GameObject proj3 = new GameObject();
                        proj3.AddComponent<Projectile>();
                        proj3.transform.position = this.transform.position;
                        proj3.GetComponent<Projectile>().SetDirection(d4);

                        Vector3 d5 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 202.5f + (5 * i))), Mathf.Sin(Mathf.Deg2Rad * (up + 202.5f + (5 * i))));
                        GameObject proj4 = new GameObject();
                        proj4.AddComponent<Projectile>();
                        proj4.transform.position = this.transform.position;
                        
                        proj4.GetComponent<Projectile>().SetDirection(d5);

                        Vector3 d6 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 247.5f + (5 * i))), Mathf.Sin(Mathf.Deg2Rad * (up + 247.5f + (5 * i))));
                        GameObject proj5 = new GameObject();
                        proj5.AddComponent<Projectile>();
                        proj5.transform.position = this.transform.position;
                        proj5.GetComponent<Projectile>().SetDirection(d6);

                        Vector3 d7 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 292.5f + (5 * i))), Mathf.Sin(Mathf.Deg2Rad * (up + 292.5f + (5 * i))));
                        GameObject proj6 = new GameObject();
                        proj6.AddComponent<Projectile>();
                        proj6.transform.position = this.transform.position;
                        proj6.GetComponent<Projectile>().SetDirection(d7);

                        Vector3 d8 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 337.5f + (5 * i))), Mathf.Sin(Mathf.Deg2Rad * (up + 337.5f + (5 * i))));
                        GameObject proj7 = new GameObject();
                        proj7.AddComponent<Projectile>();
                        proj7.transform.position = this.transform.position;
                        proj7.GetComponent<Projectile>().SetDirection(d8);
                    }
                }
                else {
                    Vector3 d1 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 22.5f)), Mathf.Sin(Mathf.Deg2Rad * (up + 22.5f)));
                    GameObject proj = new GameObject();
                    proj.AddComponent<Projectile>();
                    proj.transform.position = this.transform.position;
                    proj.GetComponent<Projectile>().SetDirection(d1);

                    Vector3 d2 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 67.5f)), Mathf.Sin(Mathf.Deg2Rad * (up + 67.5f)));
                    GameObject proj1 = new GameObject();
                    proj1.AddComponent<Projectile>();
                    proj1.transform.position = this.transform.position;
                    proj1.GetComponent<Projectile>().SetDirection(d2);

                    Vector3 d3 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 112.5f)), Mathf.Sin(Mathf.Deg2Rad * (up + 112.5f)));
                    GameObject proj2 = new GameObject();
                    proj2.AddComponent<Projectile>();
                    proj2.transform.position = this.transform.position;
                    proj2.GetComponent<Projectile>().SetDirection(d3);

                    Vector3 d4 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 157.5f)), Mathf.Sin(Mathf.Deg2Rad * (up + 157.5f)));
                    GameObject proj3 = new GameObject();
                    proj3.AddComponent<Projectile>();
                    proj3.transform.position = this.transform.position;
                    proj3.GetComponent<Projectile>().SetDirection(d4);

                    Vector3 d5 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 202.5f)), Mathf.Sin(Mathf.Deg2Rad * (up + 202.5f)));
                    GameObject proj4 = new GameObject();
                    proj4.AddComponent<Projectile>();
                    proj4.transform.position = this.transform.position;
                    proj4.GetComponent<Projectile>().SetDirection(d5);

                    Vector3 d6 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 247.5f)), Mathf.Sin(Mathf.Deg2Rad * (up + 247.5f)));
                    GameObject proj5 = new GameObject();
                    proj5.AddComponent<Projectile>();
                    proj5.transform.position = this.transform.position;
                    proj5.GetComponent<Projectile>().SetDirection(d6);

                    Vector3 d7 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 292.5f)), Mathf.Sin(Mathf.Deg2Rad * (up + 292.5f)));
                    GameObject proj6 = new GameObject();
                    proj6.AddComponent<Projectile>();
                    proj6.transform.position = this.transform.position;
                    proj6.GetComponent<Projectile>().SetDirection(d7);

                    Vector3 d8 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (up + 337.5f)), Mathf.Sin(Mathf.Deg2Rad * (up + 337.5f)));
                    GameObject proj7 = new GameObject();
                    proj7.AddComponent<Projectile>();
                    proj7.transform.position = this.transform.position;
                    proj7.GetComponent<Projectile>().SetDirection(d8);
                }

                break;
        }
    }

}
