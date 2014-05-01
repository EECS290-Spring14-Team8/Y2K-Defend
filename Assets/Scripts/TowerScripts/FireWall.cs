using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FireWall : Turret {

	public float ready = 0f;
	public ParticleSystem particles;
	public List<Dude> dudes = new List<Dude>();
	

	// Use this for initialization
	void Start () {
		this.attackspeed = .5f;
		particles = GetComponent<ParticleSystem> ();
		particles.Pause ();
		this.Power = 10;
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

	new public void shoot() {
		int shot = 0;
		for(int i = dudes.Count - 1; i >= 0; i--){
			if (dudes[i] != null){
				dudes[i].takeDamage(this.Power);
				shot++;
			}
			else {
				dudes.RemoveAt(i);
			}
			if (shot > 8)
				return;
			audio.Play();
		}

	}
}
