using UnityEngine;
using System.Collections;

public class Dude : MonoBehaviour {

	public int health = 100;
	public int moneydropped;
	public static double dudespeed = 10;
	public double speed = 10;

	// Use this for initialization
	void Start () {
	
	}

	public void takeDamage(int damage) {
		health -= damage;
		if (health <= 0) {
			//deal with money
			Destroy(this.gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
