using UnityEngine;
using System.Collections;

public class CameraView : MonoBehaviour {
	private Vector3 dragorigin;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//scrolls with right click
	scrollMap();
	}
	void scrollMap(){
		if(Input.GetMouseButtonDown(1)){
			 dragorigin = Input.mousePosition;
			return;
		}
		if (!Input.GetMouseButton(1)) return;

		Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragorigin);
		
		Vector3 move = new Vector3(pos.x * .2f, 0, pos.y * .2f);
		
		
		
		transform.Translate(move, Space.World);  


				//transform.Translate(-touchDeltaPosition.x * 0.02f, -touchDeltaPosition.y * 0.02f, 0);
		}
}
