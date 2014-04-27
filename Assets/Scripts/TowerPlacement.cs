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
	
	GUISkin Button1Skin;
	GUISkin Button2Skin;
	GUISkin Button3Skin;

	// Use this for initialization
	void Start () {
		selectedTower = towerPrefab1;
		//Screen.showCursor = false;
		//Aoe = (GameObject)Instantiate (aoePrefab, Vector3.zero, Quaternion.identity);
		//InstantiateTower ();
		
		
		//camera = Camera.current;
		towerGap = 3;
		aoeRadius = 30;
		aoePrefab.transform.localScale = new Vector3 (2*aoeRadius, .02f, 2*aoeRadius);
		
		Button1Skin = DefaultSkin;
		Button2Skin = DefaultSkin;
		Button3Skin = DefaultSkin;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (tower != null) {
			mousePos = Input.mousePosition;
			if (Input.GetMouseButtonDown (0))
				OnMouseClick ();
			if(Input.GetKeyDown ("escape"))
				OnEscapeClick();
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray,out hit,Mathf.Infinity,1<<8)){
				tower.transform.position = hit.point + new Vector3(0,5,0);
			}
			else{
				mousePos.z = camera.transform.position.y - .3f;//height of the camera
				tower.transform.position = camera.ScreenToWorldPoint (mousePos);
			}
			
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

	bool CheckTowerPosition(){//sees if the tower is on the raised portion of the map or in one of the valleys
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray,out hit,Mathf.Infinity,1<<8)){
			return true;
		}
		else{
			mousePos.z = camera.transform.position.y - .3f;//height of the camera
			return false;
		}
		}
	//checks to see if the current positioin is valid for the turret
	bool CheckPosition(){
		//checks to see if the tower is out of bounds
		/*if(tower.transform.position.x > 10 || tower.transform.position.x < -5 || tower.transform.position.z>5||tower.transform.position.z< -10){
			Aoe.renderer.material = Negative;
			return false;
		}*/
		if (!CheckTowerPosition()) {//if the tower is in the trenches where you can't place it
			Aoe.renderer.material = Negative;
			return false;
				}
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
		
		Screen.showCursor = true;
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

	void OnEscapeClick(){
		Screen.showCursor = true;
		Destroy (Aoe);
		Destroy (tower);
		}
	
	GameObject InstantiateTower(){
		tower = (GameObject)Instantiate (selectedTower, Vector3.zero, Quaternion.identity);
		Aoe = (GameObject)Instantiate (aoePrefab, Vector3.zero, Quaternion.identity);
		//aoePrefab.transform.localScale += new Vector3 (aoeRadius, 0, aoeRadius);
		return tower;
	}
	
	public GUISkin NegativeSkin;
	public GUISkin DefaultSkin;
	
	void OnGUI () {
				if (!UnitSpawner.spawnReady && UnitSpawner.spawned == 0) {
						if (GUI.Button (new Rect (Screen.width - 110, 10, 100, 50), "Start Wave")) {
								UnitSpawner.spawnReady = true;
						}
		
		
		
		
						//the various rectangles for boxes
						Rect boxRect = new Rect (10, 10, 110, 140);
						Rect tower1Rect = new Rect (20, 40, 90, 25);
						Rect tower2Rect = new Rect (20, 70, 90, 25);
						Rect tower3Rect = new Rect (20, 100, 90, 25);
						Rect moneyRect = new Rect (10, 160, 100, 25);	//shows how much money you have
		
						GUI.skin = DefaultSkin;
						//does every button have its own skin?
		
						// Make a background box
						GUI.Box (boxRect, "Tower Menu");
						//GUI.Label (new Rect (0, 40, 100, 40), GUI.tooltip);
		
						GUI.Label (moneyRect, " Money: " + Money.getMoneyAmount ().ToString ());
		
						GUI.skin = Button1Skin;

						if (GUI.Button (tower1Rect, new GUIContent ("Basic Tower"))) {
								// nothing happens when you don't have enough $$$
								if (Money.getMoneyAmount () >= 100) {
										TowerPlacement.selectedTower = towerPrefab1;
										Destroy (tower);
										Destroy (Aoe);
										Money.adjustMoneyAmount (-100);
										InstantiateTower ();

										Screen.showCursor = false;
								} else {

								}
			
						}	//if the mouse hovers over the buttton then the tooltip appears describing the tower
						if (tower1Rect.Contains (Event.current.mousePosition)) {
								if (Money.getMoneyAmount () >= 100) {
										GUI.tooltip = "100 Gold. Can be upgraded.";
								} else {
										GUI.tooltip = "Cannot afford!";
								}
								GUI.Label (new Rect (120, 40, 200, 120), GUI.tooltip);
						}
		
						GUI.skin = Button2Skin;
		
						// Make the second button.
						if (GUI.Button (tower2Rect, new GUIContent ("Tower 2", "Tower 2 Description"))) {
								TowerPlacement.selectedTower = towerPrefab2;
								Destroy (tower);
								Destroy (Aoe);
								InstantiateTower ();
								Screen.showCursor = false;
						}//tooltip describing the tower
						if (tower2Rect.Contains (Event.current.mousePosition))
								GUI.Label (new Rect (110, 70, 80, 100), GUI.tooltip);
		
						GUI.skin = Button3Skin;
		
						if (GUI.Button (tower3Rect, new GUIContent ("Tower 3", "Tower 3 Description"))) {
								TowerPlacement.selectedTower = towerPrefab3;
								Destroy (tower);
								Destroy (Aoe);
								InstantiateTower ();
								Screen.showCursor = false;
						}//tooltip describing the tower
						if (tower3Rect.Contains (Event.current.mousePosition))
								GUI.Label (new Rect (110, 100, 80, 100), GUI.tooltip);
				}
		}
}
