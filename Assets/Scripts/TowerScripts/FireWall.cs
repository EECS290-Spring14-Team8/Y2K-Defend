using UnityEngine;
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
		foreach (Dude x in dudes) {
			x.takeDamage(this.Power);
		}
	}
}
