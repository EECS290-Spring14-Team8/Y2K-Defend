using UnityEngine;
using System.Collections;

public class MotherBoardScript : MonoBehaviour {
	
	public static int health = 200;
	public Material thisMat;
	public GUITexture hurtEffect;
	
	// Use this for initialization
	void Start () {
		//thisMat = this.gameObject.GetComponent<Shader>();
		thisMat.color = Color.green;

		hurtEffect.enabled = false;
		hurtEffect.transform.position = new Vector3 (0.5f, 0.5f, 0f);
		hurtEffect.guiTexture.pixelInset = new Rect (-Screen.width / 2, -Screen.height / 2, Screen.width, Screen.height);
		hurtEffect.guiTexture.color = new Color (1.0f, 1.0f, 1.0f, 30 / 255.0f);

	}
	
	public void takeDamage(int damage) {
		if (!audio.isPlaying) audio.Play();
		health -= damage;
		thisMat.color = Color.Lerp (thisMat.color, Color.red, .01f * damage);
		StartCoroutine (showEffect());
		Debug.Log ("Motherboard: Taking " + damage + " damage!");
	}
	
	// Update is called once per frame
	void Update () {
		//this.takeDamage (2);
		if (health <= 0) {
			//gameover condition		
			Application.LoadLevel(2);
		}
	}
	
	private IEnumerator showEffect() {
		hurtEffect.guiTexture.color = new Color (1.0f, 1.0f, 1.0f, 30 / 255.0f);

		hurtEffect.enabled = true;
		yield return new WaitForSeconds(0.1f);
		hurtEffect.guiTexture.color = new Color (1.0f, 1.0f, 1.0f, 20 / 255.0f);
		yield return new WaitForSeconds(0.1f);
		hurtEffect.guiTexture.color = new Color (1.0f, 1.0f, 1.0f, 10 / 255.0f);
		yield return new WaitForSeconds(0.1f);
		hurtEffect.enabled = false;

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
