using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	private RaycastHit hitInfo;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	//Based on the click a different interaction will happen on the main menu
	void Update () {
		
		
		if( Physics.Raycast( Camera.main.ScreenPointToRay( Input.mousePosition ), out hitInfo ) ){
			if(Input.GetMouseButtonDown(0)){
				//loads the Game Scen
				if(hitInfo.collider.name == "Play Game"){
					Application.LoadLevel(1);
				}
				//shoots the tank on the mainmenu
			} 
			
		}
	}
	
}
