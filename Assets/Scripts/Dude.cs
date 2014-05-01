using UnityEngine;
using System.Collections;

public class Dude : MonoBehaviour {

	public int health = 100;
	public int moneydropped;
	public static double dudespeed = 10;
	public double speed = 20;
	public int damage = 1;
	public Money money;

	// Use this for initialization
	void Start () {
		this.gameObject.GetComponent<AIPathFinder> ().speed = (float)this.speed;
	}

	public void takeDamage(int damage) {
		health -= damage;
		if (health <= 0) {
			this.die();
		}
	}

	public void die() {
		Money.adjustMoneyAmount (5);
		UnitSpawner.spawned--;
		Destroy(gameObject);
		Debug.Log(UnitSpawner.spawned);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnControllerColliderHit(ControllerColliderHit hit){
		if(hit.gameObject.tag == "MotherBoard"){
			MotherBoardScript m = hit.gameObject.GetComponent<MotherBoardScript>();
			m.takeDamage(damage);
			UnitSpawner.spawned--;
			Destroy(gameObject);
		}

	}
}
