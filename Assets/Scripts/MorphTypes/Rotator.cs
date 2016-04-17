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
        if (this.gameObject.tag == "Player") {
            float h = Input.GetAxis("Rotational");
            this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, this.transform.rotation.eulerAngles.z + (h * speed * Time.deltaTime)));
        }
        else {
            this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, this.transform.rotation.eulerAngles.z + (speed * Time.deltaTime)));
        }
    }

    public virtual void Upgrade() {
        this.speed += 2f;
    }

}
