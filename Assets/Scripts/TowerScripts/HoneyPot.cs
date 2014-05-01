using UnityEngine;
using System.Collections;

public class HoneyPot : Turret {

	public float slowAmount = .2f;

	// Use this for initialization
	void Start () {
		this.range = 20;
		this.upgradeCost = 800;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
