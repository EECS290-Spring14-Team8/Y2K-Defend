using UnityEngine;
using System.Collections;

public class YellowOnHover : MonoBehaviour {
	private Color originalColor;
	public AudioClip UISound;

	// Use this for initialization
	void Start () {
		originalColor = this.renderer.material.color;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//When hovering the mouse cursor on the object (i.e. its collider), change its material color to yellow
	void OnMouseEnter() {
		this.renderer.material.color = UnityEngine.Color.yellow;
		audio.PlayOneShot (UISound);
	}

	//When hovering the mouse cursor OUT of the object, change its material color back to white
	void OnMouseExit() {
		this.renderer.material.color = originalColor;
	}

}
