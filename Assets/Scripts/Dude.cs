using UnityEngine;
using System.Collections;

public class Dude : MonoBehaviour {

	public int health = 100;
	public int moneydropped;
	public static double dudespeed = 10;
	public double speed = 10;
	public int damage = 1;
	public Money money;

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
		Money.adjustMoneyAmount (50);
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
