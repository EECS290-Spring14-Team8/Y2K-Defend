using UnityEngine;
using System.Collections;

public class Dude : MonoBehaviour {

	public int health;
	public int moneydropped;

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
