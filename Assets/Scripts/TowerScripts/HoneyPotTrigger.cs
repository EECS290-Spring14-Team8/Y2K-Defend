using UnityEngine;
using System.Collections;

public class HoneyPotTrigger : MonoBehaviour {

	public HoneyPot stats;

	// Use this for initialization
	void Start () {
		this.GetComponent<SphereCollider> ().radius = stats.range;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Enemy")) {
			float speed = (float)other.gameObject.GetComponent<Dude> ().speed;
			other.gameObject.GetComponent<AIPathFinder>().speed = (float)speed*(1 - stats.slowAmount);
		}
	}
	
	void OnTriggerExit(Collider other) {
		if (other.gameObject.CompareTag ("Enemy")) {
			other.gameObject.GetComponent<AIPathFinder>().speed = (float)other.gameObject.GetComponent<Dude>().speed;
		}
	}
}
