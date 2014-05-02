using UnityEngine;
using System.Collections;

public class FireWall2 : FireWall {

	// Use this for initialization
	void Start () {
		this.attackspeed = .45f;
		particles = GetComponent<ParticleSystem> ();
		particles.Pause ();
		this.Power = 35;
		this.range = 30;
		this.upgradeCost = 800;
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
