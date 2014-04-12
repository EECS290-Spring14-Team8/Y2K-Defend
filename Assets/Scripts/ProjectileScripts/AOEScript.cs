using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * handles the AOE damage of the exploding cannonball
 */
public class AOEScript : MonoBehaviour {
	private List<Dude> inArea; // list of Tank AIs in the trigger area
	
	// Use this for initialization
	void Start () { // initializes the list
		inArea = new List<Dude>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/*
	 * does damage to all AIs in the list
	 */
	public void Explode() {
		foreach (Dude x in inArea) {
			x.takeDamage (15);
		}
		
	}

	/*
	 * puts AIs into the list
	 * @param other the object entering the area
	 */
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Enemy")) {
			inArea.Add (other.gameObject.GetComponent<Dude> ());
		}
	}

	/*
	 * takes AIs out of the list
	 * @param other the object leaving the area
	 */
	void OnTriggerExit(Collider other) {
		if (other.gameObject.CompareTag ("Enemy")) {
			inArea.Remove (other.gameObject.GetComponent<Dude> ());
		}
	}
}
