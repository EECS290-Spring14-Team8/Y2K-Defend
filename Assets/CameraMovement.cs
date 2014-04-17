using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	float movementSpeed;
	float zoomSpeed;
	// Use this for initialization
	void Start () {
		movementSpeed = 20;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey ("w"))
		  		this.transform.position += Vector3.forward*movementSpeed*Time.deltaTime;
		if (Input.GetKey ("a"))
				this.transform.position -= Vector3.right * movementSpeed * Time.deltaTime;
		if (Input.GetKey ("s"))
				this.transform.position -= Vector3.forward * movementSpeed * Time.deltaTime;
		if (Input.GetKey ("d"))
				this.transform.position += Vector3.right * movementSpeed * Time.deltaTime;

	}
}
