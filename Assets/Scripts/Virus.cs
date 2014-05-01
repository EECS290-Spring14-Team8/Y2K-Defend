using UnityEngine;
using System.Collections;

public class Virus : Dude {

	// Use this for initialization
	void Start () {
		this.damage = 1;
		this.speed = 35;
		this.gameObject.GetComponent<AIPathFinder> ().speed = (float)this.speed;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
