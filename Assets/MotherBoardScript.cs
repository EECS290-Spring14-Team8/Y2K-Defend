using UnityEngine;
using System.Collections;

public class MotherBoardScript : MonoBehaviour {

	public int health = 200;
	public Material thisMat;

	// Use this for initialization
	void Start () {
		//thisMat = this.gameObject.GetComponent<Shader>();
		thisMat.color = Color.green;
	}

	void takeDamage(int damage) {
		health -= damage;
		thisMat.color = Color.Lerp (thisMat.color, Color.red, .01f * damage);
	}
	
	// Update is called once per frame
	void Update () {
		//this.takeDamage (2);
		if (health <= 200) {
			//gameover condition		
		}
	}

	void OnCollisionEnter(Collision other) {
		if (other.gameObject.tag.Equals("Enemy")) {
			this.takeDamage(other.gameObject.GetComponent<Dude>().damage);
			Destroy(other.gameObject.transform.parent);
			UnitSpawner.spawned--;
		}
	}
}
