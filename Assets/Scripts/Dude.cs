using UnityEngine;
using System.Collections;

public class Dude : MonoBehaviour {

	public int health = 100;
	public int moneydropped;
	public static double dudespeed = 10;
	public double speed = 10;
	public int damage = 1;

	// Use this for initialization
	void Start () {
	
	}

	public void takeDamage(int damage) {
		health -= damage;
		if (health <= 0) {
			this.die();
		}
	}

	public void die() {
		//deal with money
		UnitSpawner.spawned--;
		Destroy(this.gameObject.transform.parent);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
