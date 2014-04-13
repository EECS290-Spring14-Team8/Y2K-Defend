using UnityEngine;
using System.Collections;

/* This script is for Basic3 tower (the one with rotating barrels)
 * When firing, enable this script
 * Attach to the "turret" prefab.
 */

public class RotateBarrel : MonoBehaviour {
	public GameObject barrels;
	Vector3 rotationAmount = new Vector3(0,0,1200f);
	public bool isFiring;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (isFiring) {
			barrels.transform.Rotate (rotationAmount * Time.smoothDeltaTime);
		}
	}
}
