using UnityEngine;
using System.Collections;

public class TowerPlacement : MonoBehaviour {
	
	Vector3 mousePos;
	public static GameObject selectedTower; //other scripts can change this object and change the selected tower

	public GameObject towerPrefab1;
	public GameObject towerPrefab2;
	public GameObject towerPrefab3;
	
	public GameObject aoePrefab;
	public Material Posotive;
	public Material Negative;
	
	GameObject Aoe;
	float aoeRadius;
	GameObject tower;
	public Camera camera;
	GameObject[] towerList;//the array of any towers 
	float towerGap;//the smallest distance allowed between towers
	
	public GUISkin mySkin;
	
	// Use this for initialization
	void Start () {
		selectedTower = towerPrefab1;
		Screen.showCursor = false;
		//Aoe = (GameObject)Instantiate (aoePrefab, Vector3.zero, Quaternion.identity);
		//InstantiateTower ();
		
		
		//camera = Camera.current;
		towerGap = 3;
		aoeRadius = 5;
		aoePrefab.transform.localScale = new Vector3 (aoeRadius, .02f, aoeRadius);
	}
	
	// Update is called once per frame
	void Update () {
		if (tower != null) {
			mousePos = Input.mousePosition;
			if (Input.GetMouseButtonDown (0))
				OnMouseClick ();
			mousePos.z = camera.transform.position.y - .3f;//height of the camera
			tower.transform.position = camera.ScreenToWorldPoint (mousePos);
			CheckPosition ();
			Aoe.transform.position = tower.transform.position;
		}
		
		//if the mouse leaves the grid then the tower disappears and the mouse returns
		/*if (mousePos.x > 10 || mousePos.x < 0 || mousePos.y < 0 || mousePos.y > 10) {
						Screen.showCursor = true;
						Destroy (tower);
				} else {
						if (tower == null) {
								tower = (GameObject)Instantiate (selectedTower, Vector3.zero, Quaternion.identity);
						}
			mousePos = Input.mousePosition;
			CheckPosition ();
			if (Input.GetMouseButtonDown(0))
				OnMouseClick ();
			mousePos.z = depth;
			tower.transform.position  = camera.ScreenToWorldPoint (mousePos);
			Aoe.transform.position = tower.transform.position;
				}*/
	}
	//checks to see if the current positioin is valid for the turret
	bool CheckPosition(){
		//checks to see if the tower is out of bounds
		/*if(tower.transform.position.x > 10 || tower.transform.position.x < -5 || tower.transform.position.z>5||tower.transform.position.z< -10){
			Aoe.renderer.material = Negative;
			return false;
		}*/
		towerList = GameObject.FindGameObjectsWithTag ("tower");
		for (int i=0; i<towerList.Length; i++) {
			float distance = Vector3.Distance (towerList[i].transform.position, tower.transform.position);
			if(distance < towerGap){
				Aoe.renderer.material = Negative;
				return  false;
			}
		}
		Aoe.renderer.material = Posotive;
		return true;
	}
	//when the mouse is clicked it places the turret at the location and creates another turret to follow the mouse
	void OnMouseClick(){
		if (CheckPosition ()) {
						tower.tag = "tower";
						Destroy (Aoe);
						InstantiateTower ();
						Destroy (tower);
						Destroy (Aoe);
						Screen.showCursor = true;
				} else {
						Destroy (Aoe);
						Destroy (tower);
				}

	}
	
	GameObject InstantiateTower(){
		tower = (GameObject)Instantiate (selectedTower, Vector3.zero, Quaternion.identity);
		Aoe = (GameObject)Instantiate (aoePrefab, Vector3.zero, Quaternion.identity);
		//aoePrefab.transform.localScale += new Vector3 (aoeRadius, 0, aoeRadius);
		return tower;
	}
	void OnGUI () {
		
		GUI.skin = mySkin;
		// Make a background box
		GUI.Box(new Rect(10,10,100,140), "Loader Menu");
		//GUI.Label (new Rect (0, 40, 100, 40), GUI.tooltip);
		
		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUI.Button (new Rect (20, 40, 80, 20),"Tower 1")) {
			
			TowerPlacement.selectedTower = towerPrefab1;
			Destroy (tower);
			Destroy (Aoe);
			InstantiateTower ();
		}
		
		// Make the second button.
		if(GUI.Button (new Rect (20, 70, 80, 20), "Tower 2")) {
			TowerPlacement.selectedTower = towerPrefab2;
			Destroy (tower);
			Destroy (Aoe);
			InstantiateTower ();
		}
		
		if (GUI.Button (new Rect (20, 100, 80, 20), "Tower 3")) {
			TowerPlacement.selectedTower = towerPrefab3;
			Destroy (tower);
			Destroy (Aoe);
			InstantiateTower ();
		}
	}
}
