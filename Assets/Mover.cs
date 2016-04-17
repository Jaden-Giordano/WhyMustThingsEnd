using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

    Timer timer;

    [SerializeField]
    protected float destinationCooldown = 10f;

    [SerializeField]
    protected float speed = 1f;

    protected Vector3 destination;

	// Use this for initialization
	void Awake () {
        init();
	}
	
    protected virtual void init() {
        this.timer = new Timer();
    }

	// Update is called once per frame
	void Update () {
        tick();
	}

    protected virtual void tick() {
        if (destination == null) {
            this.destination = new Vector3((Random.value * 1000) - 500, (Random.value * 1000) - 500);
        }
        else if (timer.elapsedTime > destinationCooldown && Random.value > .9f) {
            this.destination = new Vector3((Random.value * 1000) - 500, (Random.value * 1000) - 500);
            this.timer.Reset();
        }
        if (destination != null) {
            if (Vector3.Distance(this.transform.position, destination) > .3f) {
                this.transform.position = this.transform.position + ((destination - this.transform.position).normalized * speed * Time.deltaTime);
            }
        }
    }

    public virtual void Upgrade() {
        this.speed += 0.5f;
    }

}
