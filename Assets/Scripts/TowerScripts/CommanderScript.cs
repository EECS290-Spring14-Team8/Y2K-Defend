using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CommanderScript : Turret {

	public List<Turret> dudes = new List<Turret>();

	// Use this for initialization
	void Start () {
		this.Power = 10;
		this.attackspeed = .2f;

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
