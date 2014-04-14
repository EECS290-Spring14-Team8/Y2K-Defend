using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {
	
	public GameObject target;
	public GameObject projectile;
	public int Power;
	public GameObject turret;
	public float attackspeed;
	public bool sighted = false;
	public GameObject upgrade;
	
	// Use this for initialization
	void Start () {
		
	}
	
	public void shoot() {
		//fire at target
	}
	
	// Update is called once per frame
	void Update () {
		/*if (target != null) {
			Vector3 amttorotate;
			amttorotate = Vector3.RotateTowards (turret.transform.forward, target.transform.position - turret.transform.position, 6f, 6f);	
			Turret.transform.rotation = Quaternion.LookRotation (amttorotate, new Vector3 (0f, 1f, 0f));
		}*/

		// turret.transform.rotation = Quaternion.LookRotation (amttorotate, new Vector3 (0f, 1f, 0f));
	}

	void OnGUI(){
		if (GameManager.selectedScript == this) {
			GUI.Box (new Rect (100, Screen.height - 100, Screen.width - 500, 100), GUIContent.none);
			if (GUI.Button(new Rect(110,Screen.height-90,50,50), "upgrade")) {
				Vector3 oldpos = this.gameObject.transform.position;
				this.gameObject.transform.Translate(0f,1000f,0f);
				GameManager.selectedTurret = (GameObject)Instantiate(this.upgrade, oldpos, Quaternion.identity);
				GameManager.selectedScript = GameManager.selectedTurret.GetComponent<Turret>();
				Destroy(this.gameObject);
			}
		}
	}
	
}