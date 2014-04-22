using UnityEngine;
using System.Collections;

public class BasicTurretTrigger : MonoBehaviour {

	public Turret turret;
	public int sighted = 0;
	// Use this for initialization
	void Start () {
		this.gameObject.GetComponent<SphereCollider> ().radius = turret.range;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter(Collider other) {
		if (other.tag.Equals("Enemy")) {
			turret.sighted = true;
			sighted++;
			if (turret.target == null) {
				turret.target = other.gameObject;
			}
		}

	}

	// checks to see if there are any more enemies in range to fire at, chooses furthest away enemy in range
	void OnTriggerExit(Collider other) {
		if (other.tag.Equals("Enemy")){
			sighted--;
			if (sighted == 0 || other.gameObject == turret.target) {
				turret.target = null;
			}
		}
	}
}
