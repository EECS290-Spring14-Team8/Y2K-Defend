using UnityEngine;
using System.Collections;

public class TowerPlacement : MonoBehaviour {
	
	Vector3 mousePos;
	public static GameObject selectedTower; //other scripts can change this object and change the selected tower
	
	public GameObject towerPrefab1;
	public GameObject towerPrefab2;
	public GameObject towerPrefab3;
	public GameObject towerPrefab4;
	
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
	GUISkin Button4Skin;

	public Texture towerIcon1;
	public Texture towerIcon2;
	public Texture towerIcon3;
	public Texture towerIcon4;

	public AudioClip clickSound, noSound, incomingSound;

	int waveNum = 0;
	
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
			audio.PlayOneShot(clickSound);
			tower.tag = "tower";
			Destroy (Aoe);
			InstantiateTower ();
			Destroy (tower);
			Destroy (Aoe);
			Screen.showCursor = true;
		} else {
			audio.PlayOneShot (noSound);
			Destroy (Aoe);
			Destroy (tower);
		}
	}
	
	void OnEscapeClick(){
		Screen.showCursor = true;
		Destroy (Aoe);
		Destroy (tower);
		audio.PlayOneShot (noSound);
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
		GUI.Box (new Rect(Screen.width/2 - 60, 10, 120, 25), "Wave " + waveNum.ToString() + " / " + MotherBoardScript.health.ToString() + " Life");

		// during wave, the menus will disappear
		if (!UnitSpawner.spawnReady && UnitSpawner.spawned == 0) {
			if (GUI.Button (new Rect (Screen.width - 110, 10, 100, 50), "Start Wave")) {
				UnitSpawner.spawnReady = true;
				waveNum++;
				audio.PlayOneShot(incomingSound);

			}
			
			
			
			
			//the various rectangles for boxes
			Rect boxRect = new Rect (10, 10, 120, 500);
			Rect tower1Rect = new Rect (20, 40, 100, 100);
			Rect tower2Rect = new Rect (20, 160, 100, 100);
			Rect tower3Rect = new Rect(20, 280, 100, 100);
			Rect tower4Rect = new Rect(20, 400, 100, 100);
			// Rect tower3Rect = new Rect (20, 280, 100, 100);
			
			
			GUI.skin = DefaultSkin;
			//does every button have its own skin?
			
			// Make a background box
			GUI.Box (boxRect, "Money: " + Money.getMoneyAmount().ToString());
			//GUI.Label (new Rect (0, 40, 100, 40), GUI.tooltip);

			GUI.skin = Button1Skin;
			
			if (GUI.Button (tower1Rect, new GUIContent (towerIcon1))) {
				// nothing happens when you don't have enough $$$
				if (Money.getMoneyAmount () >= 150) {
					TowerPlacement.selectedTower = towerPrefab1;
					Destroy (tower);
					Destroy (Aoe);
					Money.adjustMoneyAmount (-150);
					InstantiateTower ();
					Screen.showCursor = false;
				}
				
			}	//if the mouse hovers over the buttton then the tooltip appears describing the tower
			if (tower1Rect.Contains (Event.current.mousePosition)) {
				if (Money.getMoneyAmount () >= 150) {
					GUI.tooltip = "[150 Gold] Basic: Shoots enemies one by one.\n" +
						          "Can be upgraded for faster, stronger fire.";
				} else {
					GUI.tooltip = "[150 Gold] Cannot afford!";
				}
				GUI.Label (new Rect (140, 75, 500, 300), GUI.tooltip);
			}
			
			
			
			GUI.skin = Button2Skin;
			
			// Make the second button.
			if (GUI.Button (tower2Rect, new GUIContent (towerIcon2))) {
				if (Money.getMoneyAmount() >= 300) {
					TowerPlacement.selectedTower = towerPrefab2;
					Destroy (tower);
					Destroy (Aoe);
					Money.adjustMoneyAmount(-300);
					InstantiateTower ();
					Screen.showCursor = false;
				}
			}//tooltip describing the tower
			if (tower2Rect.Contains (Event.current.mousePosition)) {
				if (Money.getMoneyAmount () >= 300) {
					GUI.tooltip = "[300 Gold] FireWall: Damages all enemies in the range.\n" +
						          "Can be upgraded for faster, stronger fire.";
				} else {
					GUI.tooltip = "[300 Gold] Cannot afford!";
				}
				GUI.Label (new Rect (140, 200, 500, 300), GUI.tooltip);
				
			}




			GUI.skin = Button3Skin;
			
			if (GUI.Button (tower3Rect, new GUIContent (towerIcon3))) {
				if (Money.getMoneyAmount() >= 1000) {
					TowerPlacement.selectedTower = towerPrefab3;
					Destroy (tower);
					Destroy (Aoe);
					Money.adjustMoneyAmount(-1000);
					InstantiateTower ();
					Screen.showCursor = false;
				}
			}//tooltip describing the tower
			if (tower3Rect.Contains (Event.current.mousePosition)) {
				if (Money.getMoneyAmount () >= 1000) {
					GUI.tooltip = "[1000 Gold] Web Network: Buffs nearby towers.\n" +
						"Can be upgraded for increased damage and attack speed.";
				} else {
					GUI.tooltip = "[1000 Gold] Cannot afford!";
				}
				GUI.Label (new Rect (140, 320, 500, 300), GUI.tooltip);
			}







			if (GUI.Button (tower4Rect, new GUIContent (towerIcon4))) {
				if (Money.getMoneyAmount() >= 500) {
					TowerPlacement.selectedTower = towerPrefab4;
					Destroy (tower);
					Destroy (Aoe);
					Money.adjustMoneyAmount(-500);
					InstantiateTower ();
					Screen.showCursor = false;
				}
			}

			if (tower4Rect.Contains (Event.current.mousePosition)) {
				if (Money.getMoneyAmount () >= 500) {
					GUI.tooltip = "[500 Gold] HoneyPot: Slows down nearby enemies.\n" +
						"Can be upgraded for more slowing power and range.";
				} else {
					GUI.tooltip = "[500 Gold] Cannot afford!";
				}
				GUI.Label (new Rect (140, 440, 500, 300), GUI.tooltip);
			}

		}

		
	}
}
