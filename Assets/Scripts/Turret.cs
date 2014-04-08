using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {

	public GameObject target;
	public int Power;
	public GameObject turret;
	public double attackspeed;

	// Use this for initialization
	void Start () {
	
	}

	public void shoot() {
		//fire at target
	}
	
	// Update is called once per frame
	void Update () {
		/*if (target != null) {
			Vector3 amttorotate;
			amttorotate = Vector3.RotateTowards (turret.transform.forward, target.transform.position - turret.transform.position, 6f, 6f);	
			Turret.transform.rotation = Quaternion.LookRotation (amttorotate, new Vector3 (0f, 1f, 0f));
		}*/

	}
}
