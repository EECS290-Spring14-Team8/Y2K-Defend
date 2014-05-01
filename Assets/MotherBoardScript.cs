﻿using UnityEngine;
using System.Collections;

public class MotherBoardScript : MonoBehaviour {

	public static int health = 200;
	public Material thisMat;
	public AudioClip hitWarning;

	// Use this for initialization
	void Start () {
		//thisMat = this.gameObject.GetComponent<Shader>();
		thisMat.color = Color.green;
	}

	public void takeDamage(int damage) {
		audio.PlayOneShot (hitWarning);
		health -= damage;
		thisMat.color = Color.Lerp (thisMat.color, Color.red, .01f * damage);
	}
	
	// Update is called once per frame
	void Update () {
		//this.takeDamage (2);
		if (health <= 0) {
			//gameover condition		
			Application.LoadLevel(2);
		}

	}

	/*void OnCollisionEnter(Collision other) {
		if (other.gameObject.tag.Equals("Enemy")) {
			Debug.Log("lost health");
			this.takeDamage(other.gameObject.GetComponent<Dude>().damage);
			Destroy(other.gameObject);
			UnitSpawner.spawned--;
		}
	}*/
}
