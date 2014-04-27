using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	public float scrollSpeed;
	public float scrollArea;
	public float zoomSpeed;
	public float xcameraPositionMin;
	public float xcameraPositionMax;
	public float ycameraPositionMin;
	public float ycameraPositionMax;
	public float cameraDistanceMin;
	public float cameraDistanceMax;
	private float cameraDistance;
	private float currentDistance;
	public float zoomConstant;
	public float changeSpeed;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		currentDistance = Camera.main.orthographicSize;
		/*if(Input.GetKey ("w"))
		  		this.transform.position += Vector3.forward*movementSpeed*Time.deltaTime;
		if (Input.GetKey ("a"))
				this.transform.position -= Vector3.right * movementSpeed * Time.deltaTime;
		if (Input.GetKey ("s"))
				this.transform.position -= Vector3.forward * movementSpeed * Time.deltaTime;
		if (Input.GetKey ("d"))
				this.transform.position += Vector3.right * movementSpeed * Time.deltaTime;*/
		float mPosX = Input.mousePosition.x;
		float mPosY = Input.mousePosition.y;
		
		// Do camera movement by mouse position
		if (mPosX < scrollArea) {transform.Translate(Vector3.right * -scrollSpeed * Time.deltaTime);}
		if (mPosX >= Screen.width-scrollArea) {transform.Translate(Vector3.right * scrollSpeed * Time.deltaTime);}
		if (mPosY < scrollArea) {transform.Translate(Vector3.up * -scrollSpeed * Time.deltaTime);}
		if (mPosY >= Screen.height-scrollArea) {transform.Translate(Vector3.up * scrollSpeed * Time.deltaTime);}
		float xposition = transform.position.x;
		float zposition = transform.position.z;


		cameraDistance = -Input.GetAxis("Mouse ScrollWheel") * zoomSpeed + currentDistance;
		cameraDistance = Mathf.Clamp(cameraDistance, cameraDistanceMin, cameraDistanceMax);
		Camera.main.orthographicSize = Mathf.Lerp(currentDistance,cameraDistance,Time.deltaTime);

		transform.position = Vector3.Lerp(transform.position, new Vector3(Mathf.Clamp(xposition,xcameraPositionMin/cameraDistance*zoomConstant, xcameraPositionMax/cameraDistance*zoomConstant),transform.position.y,Mathf.Clamp(zposition,ycameraPositionMin/cameraDistance*zoomConstant, ycameraPositionMax/cameraDistance*zoomConstant)),Time.deltaTime * changeSpeed);



	}
}
