﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FireWall : Turret {

	private float ready = 0f;
	private ParticleSystem particles;
	public List<Dude> dudes = new List<Dude>();
	

	// Use this for initialization
	void Start () {
		this.attackspeed = .5f;
		particles = GetComponent<ParticleSystem> ();
		particles.Pause ();
		this.Power = 30;
	}
	
	// Update is called once per frame
	void Update () {
		if (this.sighted && Time.time > ready) {
			particles.Play();
			this.shoot();
			ready = Time.time + attackspeed;
		}
		if (!sighted) {
			particles.Pause();		
		}
	
	}

	new void shoot() {
		for(int i = dudes.Count - 1; i>=0; i--){
			if (dudes[i] != null){
				dudes[i].takeDamage(this.Power);
			}
			else{
				dudes.RemoveAt(i);
			}
		}
		/*foreach (Dude x in dudes) {
			if (x != null){
				x.takeDamage(this.Power);
			}
			else{
				dudes.Remove(x);
			}

		}*/
	}
}
