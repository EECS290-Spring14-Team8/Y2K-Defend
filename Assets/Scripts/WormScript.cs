using UnityEngine;
using System.Collections;

public class WormScript : Dude {

	AIPathFinder pathinfo;
	float nextSplit;
	public int splitTime = 2;

	// Use this for initialization
	void Start () {
		nextSplit = Time.time + splitTime;
		pathinfo = gameObject.GetComponent<AIPathFinder> ();
		health = 400;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > this.nextSplit) {
			this.nextSplit = Time.time + splitTime;
			this.split();	
		}
	
	}

	public void split() {
		GameObject unit =  (GameObject)Instantiate (gameObject, this.pathinfo.getLastWP () + new Vector3(0,2,0), Quaternion.identity);
		unit.GetComponent<AIPathFinder> ().target = pathinfo.target;
		UnitSpawner.spawned++;
	}
}
