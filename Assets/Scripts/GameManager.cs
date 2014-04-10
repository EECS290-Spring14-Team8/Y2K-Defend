using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
	public GameObject TilePrefab;
	public GameObject TurretPrefab;
	List <List<Tile>> map = new List<List<Tile>>();
	public static Turret[] TurretList;
	public int mapSize;
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
			turretIsSelected = false;
			selectedScript = null;
			selectedTurret.renderer.material.color = Color.white;
			selectedTurret = null;
		}
	}
	
	void updateCursor(){
		if (Input.GetMouseButtonDown(0)){
			RaycastHit hit;
			// Construct a ray from the current touch coordinates
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray,out hit,Mathf.Infinity,~layermask)) {
				GameObject cursorSpot = hit.collider.gameObject;
				string hitTag = cursorSpot.tag;
				if(hitTag == "tower"){
					cursorSpot.renderer.material.color = Color.blue;
					turretIsSelected = true;
					if(selectedTurret != null & cursorSpot!= selectedTurret){
						selectedTurret.renderer.material.color = Color.white;
					}
					selectedTurret = cursorSpot;
				}	
			}
		}
	}
	
}

