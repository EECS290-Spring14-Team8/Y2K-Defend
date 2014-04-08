using UnityEngine;
using System.Collections;

public class MainGUI : MonoBehaviour {

	public static int selected= -1;

	// Use this for initialization
	void Start () {
	
	}

	public void OnGUI() {
		GUI.Box (new Rect (0, 0, 100, 500), GUIContent.none);
		if (GUI.Button(new Rect(10,10,10,10), "turret image")) {
			selected = 0;
			GameManager.selectedTurret = null;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
