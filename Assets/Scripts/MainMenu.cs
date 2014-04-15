using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	private RaycastHit hitInfo;
	public GameObject Turret;
	public RotateBarrel barrelRotate;
	public GameObject startText;
	public GameObject instructionsText;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	// Based on the click a different interaction will happen on the main menu
	void Update () {
		
		
		if( Physics.Raycast( Camera.main.ScreenPointToRay( Input.mousePosition ), out hitInfo ) ){

			if(Input.GetMouseButtonDown(0)){
				//loads the Game Scene
				if(hitInfo.collider.name == "Start"){
					Application.LoadLevel(2);
				}
				//loads the instructions scene
				if(hitInfo.collider.name == "Instructions"){
					Application.LoadLevel (1);
				}

				//Fires the turret when tower is clicked
				if(hitInfo.collider.name == "Basic3") {
					barrelRotate.isFiring = true;
				}
				 
			} 
			// stops turret firing when tower is not clicked anymore
			if (Input.GetMouseButtonUp(0)) if(hitInfo.collider.name == "Basic3") barrelRotate.isFiring = false;
			
		}
	}

}
