using UnityEngine;
using System.Collections;


/*
 * handles collision behavior for the cannonball
 */
public class CannonBall : MonoBehaviour {
	public GameObject explosionSprite; // explosion visual
	public int damage;

	// Use this for initialization
	void Start () {
		
	}

	public void setDamage(int dam) {
		damage = dam;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/*
	 * handles impact-triggered explosion
	 * @param other the object being hit by the cannonball
	 */
	void OnCollisionEnter(Collision other) {
		if (other.gameObject.tag.Equals ("Enemy")) {
			other.gameObject.GetComponent<Dude>().takeDamage(damage);
			Destroy (this.gameObject);
			GameObject explClone = (GameObject)Instantiate (explosionSprite, gameObject.transform.position, Camera.main.transform.rotation);
			Destroy (explClone, 2.0f);
		}
	}
}
