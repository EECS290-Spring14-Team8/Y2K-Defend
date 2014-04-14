using UnityEngine;
using System.Collections;

public class FireWalltrigger : MonoBehaviour {

	public FireWall FireWall;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Enemy")) {
			FireWall.dudes.Add (other.gameObject.GetComponent<Dude> ());
			this.FireWall.sighted = true;
			other.gameObject.GetComponent<Dude>().speed = Dude.dudespeed * .7;
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject.CompareTag ("Enemy")) {
			FireWall.dudes.Remove (other.gameObject.GetComponent<Dude> ());
			if (FireWall.dudes.Count == 0) {
				FireWall.sighted = false;
			}
			other.gameObject.GetComponent<Dude>().speed = Dude.dudespeed;
		}
	}
}
