using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CommanderScript : Turret {


	// Use this for initialization
	void Start () {
		this.Commanded = true;
		this.Power = 10;
		this.attackspeed = .8f;
		this.range = 25;
		this.upgradeCost = 1100;
	
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
