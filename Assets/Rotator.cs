using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

    [SerializeField]
    protected float speed = 2f;
	
	// Update is called once per frame
	void Update () {
        tick();
	}

    protected virtual void tick() {
        this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, this.transform.rotation.eulerAngles.z + (speed * Time.deltaTime)));
    }

    public virtual void Upgrade() {
        this.speed += 2f;
    }

}
