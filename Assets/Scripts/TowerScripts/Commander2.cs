using UnityEngine;
using System.Collections;

public class Commander2 : CommanderScript {

	// Use this for initialization
	void Start () {
		this.Commanded = true;
		this.Power = 20;
		this.attackspeed = .65f;
		this.range = 30;
		upgradeCost = 2000;
	
	}
	
	// Update is called once per frame
	void Update () {
		GameObject[] towers = GameObject.FindGameObjectsWithTag ("tower");
		foreach (GameObject x in towers) {
			Turret target = x.GetComponent<Turret>();
			if (Vector3.Distance(this.gameObject.transform.position, x.gameObject.transform.position) <= this.range && target.Commanded == false) {
				target.Commanded = true;
				target.Power += this.Power;
				target.attackspeed *= this.attackspeed;
			}
		}
	}
}
