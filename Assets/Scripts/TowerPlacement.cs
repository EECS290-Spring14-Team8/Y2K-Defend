using UnityEngine;
using System.Collections;

public class TowerPlacement : MonoBehaviour {
	Vector3 mousePos;
	float depth;
	public GameObject towerPrefab;
	GameObject tower;
	public Camera camera;
	GameObject[] towerList;//the array of any towers 
	float towerGap;//the smallest distance allowed between towers

	// Use this for initialization
	void Start () {
		Screen.showCursor = false;
		tower = (GameObject)Instantiate (towerPrefab, Vector3.zero, Quaternion.identity);
		depth = camera.transform.position.y;//height of the camera
		//camera = Camera.current;
		towerGap = 1;
	}
	
	// Update is called once per frame
	void Update () {
		towerList = GameObject.FindGameObjectsWithTag ("tower");
		if (Input.GetMouseButtonDown(0))
				OnMouseClick ();
		mousePos = Input.mousePosition;
		mousePos.z = depth;
		tower.transform.position  = camera.ScreenToWorldPoint (mousePos);

	}
	//checks to see if the current positioin is valid for the turret
	bool CheckPosition(){
				for (int i=0; i<towerList.Length; i++) {
			float distance = Vector3.Distance (towerList[i].transform.position, tower.transform.position);
					if(distance < towerGap && distance != 0)
						return  false;
				}
		return true;
		}
	//when the mouse is clicked it places the turret at the location and creates another turret to follow the mouse
	void OnMouseClick(){
		if(CheckPosition ())
			tower = (GameObject)Instantiate (towerPrefab, Vector3.zero, Quaternion.identity);
	}
}
