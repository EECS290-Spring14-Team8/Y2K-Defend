using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
	public GameObject TurretPrefab;
	public static Turret[] TurretList;
	public bool turretIsSelected;
	public static int layermask = 1<<9;
	public static GameObject selectedTurret;
	public static Turret selectedScript;
	
	// Use this for initialization
	void Start () {
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
			Debug.Log("click");
			RaycastHit hit;
			// Construct a ray from the current touch coordinates
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray,out hit)) {
				GameObject cursorSpot = hit.collider.gameObject;
				Debug.Log(cursorSpot);
				string hitTag = cursorSpot.tag;
				if(hitTag == "tower"){
					//cursorSpot.renderer.material.color = Color.blue;
					turretIsSelected = true;
					//if(selectedTurret != null & cursorSpot!= selectedTurret){
					//	selectedTurret.renderer.material.color = Color.white;
					//}
					selectedTurret = cursorSpot;
					//selectedTurret.GetComponent<Halo>();
					selectedScript = selectedTurret.GetComponent<Turret>();
					Debug.Log("hit");
				}	
			}
		}
	}
	
}

