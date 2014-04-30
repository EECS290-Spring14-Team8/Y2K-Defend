﻿using UnityEngine;
using System.Collections;

public class FireWall2 : FireWall {

	// Use this for initialization
	void Start () {
		this.attackspeed = .5f;
		particles = GetComponent<ParticleSystem> ();
		particles.Pause ();
		this.Power = 30;
		this.range = 10;
	}
	
	// Update is called once per frame
	void Update () {
		if (this.sighted && Time.time > ready) {
			particles.Play();
			this.shoot();
			audio.Play ();
			ready = Time.time + attackspeed;
		}
		if (!sighted) {
			particles.Stop();		
		}
	}
}
