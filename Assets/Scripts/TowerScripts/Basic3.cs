﻿using UnityEngine;
using System.Collections;

public class Basic3 : Turret {

	// Use this for initialization
	void Start () {
		this.upgradeCost = 900;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (target == null) {
			retarget();		
		}
		if (target != null) {
			Vector3 amttorotate;
			amttorotate = Vector3.RotateTowards (turret.transform.position, target.transform.position - turret.transform.position, 6f, 6f);	
			turret.transform.rotation = Quaternion.LookRotation (amttorotate, new Vector3 (0f, 1f, 0f));
			this.shoot();
		}

	}
}
