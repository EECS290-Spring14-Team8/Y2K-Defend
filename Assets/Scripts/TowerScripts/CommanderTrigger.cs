using UnityEngine;
using System.Collections;

public class CommanderTrigger : MonoBehaviour {

	public CommanderScript tower;
	public int number = 0;

	// Use this for initialization
	void Start () {
		this.gameObject.GetComponent<SphereCollider> ().radius = tower.range;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("tower")) {
			other.gameObject.GetComponent<Turret>().attackspeed -= tower.attackspeed;
			other.gameObject.GetComponent<Turret>().Power += tower.Power;
			number++;
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject.CompareTag ("tower")) {
			other.gameObject.GetComponent<Turret>().attackspeed += tower.attackspeed;
			other.gameObject.GetComponent<Turret>().Power -= tower.Power;
			number--;
		}
	}
}
