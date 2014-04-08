using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
	public GameObject TilePrefab;
	public GameObject TurretPrefab;
	List <List<Tile>> map = new List<List<Tile>>();
	public static Turret[] TurretList;
	public int mapSize;
	public GameObject currentSpot = null;
	public bool turretIsSelected;
	public static int layermask = 1<<9;
	public static GameObject selectedTurret;
	public static Turret selectedScript;
	
	// Use this for initialization
	void Start () {
		generateMap();
		//generateTurrets();
	}
	
	// Update is called once per frame
	void Update () {
		updateCursor();
		turretIsSelected = hasTurret(selectedTurret);
		deselectTurret();

	}

	/* to test creating turrets
	  void generateTurrets(){
		Turret turret;
		Turret = ((GameObject)Instantiate(TurretPrefab, new Vector3( - Mathf.Floor(mapSize/2),1.4f,Mathf.Floor(mapSize/2)), Quaternion.Euler(new Vector3()))).GetComponent<Turret>();
		TurretList.Add(turret);
		ally.Add(turret);
	}*/
	
	void generateMap(){
		map = new List<List<Tile>>();
		for(int i = 0; i < mapSize; i++){
			List <Tile> row = new List<Tile>();
			for(int j = 0; j < mapSize; j++){
				Tile tile = ((GameObject)Instantiate(TilePrefab, new Vector3(1.5f*i - Mathf.Floor(mapSize/2),0,-1.5f*j+Mathf.Floor(mapSize/2)), Quaternion.Euler(new Vector3()))).GetComponent<Tile>();
				tile.gridPosition = new Vector2(i,j);
				row.Add(tile);
			}
			map.Add(row);
		}
	}

	void deselectTurret(){
		if(turretIsSelected && Input.GetKey(KeyCode.Escape)){
			currentSpot = null;
			turretIsSelected = false;
			currentSpot.renderer.material.color = Color.white;
			currentTurret = null;
			selectedTurret = null;
			selectedTurret.renderer.material.color = Color.white;
		}
	}
	
	void updateCursor(){
		if (Input.GetMouseButtonDown(0)){
			RaycastHit hit;
			// Construct a ray from the current touch coordinates
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray,out hit,Mathf.Infinity,~layermask)) {
				GameObject cursorSpot = hit.collider.gameObject;
				string hitTag = cursorSpot.name;
				if(hitTag == "Tile(Clone)"){
					cursorSpot.renderer.material.color = Color.blue;
					if(currentSpot != null & cursorSpot!= currentSpot){
						currentSpot.renderer.material.color = Color.white;
					}
					currentSpot = cursorSpot;
					if(hasTurret(currentSpot)){
						currentTurret = findCurrentTurret(selectedTurret,TurretList);
					}
				}	
			}
		}
	}
	
	public bool hasTurret(GameObject tile){
		Vector3 tileCenter = tile.transform.position;
		RaycastHit hit;
		bool checkHit = Physics.Raycast(tileCenter,Vector3.up,out hit,layermask);
		if(checkHit){
			GameObject Turret = hit.collider.gameObject;
			if( Turret.tag== "Turret"){
				if(selectedTurret != null){
					selectedTurret.renderer.material.color = Color.white;
				}
				selectedTurret = Turret;
				selectedTurret.renderer.material.color = Color.green;
				return true;
			}
		}
		return false;
		
	}
	
	//finds the current Turret in the list
	public static Turret findCurrentTurret(GameObject currentTurret, Turret[] TurretList){
		foreach(Turret turret in TurretList){
			if(currentTurret.GetComponent<Turret>() == turret)
				return turret;
		}
		return null;
	}
	

}

