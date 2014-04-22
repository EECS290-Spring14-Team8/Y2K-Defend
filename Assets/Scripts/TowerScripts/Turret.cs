using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {

	public GameObject projectile;
	public int Power;
	public GameObject turret;
	public float attackspeed;
	public float timeTillNextAtt = 0;
	public bool sighted = false;
	public GameObject upgrade;
	public GameObject target;
	public int range = 30;
	public GameObject muzzFlash;
	
	// Use this for initialization
	void Start () {
		
	}
	
	public void shoot() {
		if (Time.time > timeTillNextAtt) {
			target.gameObject.GetComponent<Dude>().takeDamage(this.Power);
			timeTillNextAtt = Time.time + attackspeed;

			//muzzleflash
			GameObject clone = (GameObject)Instantiate(muzzFlash, turret.transform.position, turret.transform.localRotation);
			Destroy(clone,0.02f);

			audio.Play();
		}
	}

	public void retarget() {
		GameObject[] dudes = GameObject.FindGameObjectsWithTag("Enemy");
		foreach(GameObject x in dudes) {
			if (x != null) {
				float d = Vector3.Distance(this.gameObject.transform.position, x.transform.position);
				if (d < range) {
					if (target != null && Vector3.Distance(this.gameObject.transform.position, target.transform.position) < d) {
						target = x;
					}
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (target == null) {
			retarget();		
		}
		if (target != null) {
			Vector3 amttorotate;
			amttorotate = Vector3.RotateTowards (turret.transform.position, target.transform.position - turret.transform.position, 6f, 6f);	
			turret.transform.rotation = Quaternion.LookRotation (amttorotate, new Vector3 (0f, 1f, 0f));
			this.shoot();
		}

		// turret.transform.rotation = Quaternion.LookRotation (amttorotate, new Vector3 (0f, 1f, 0f));
	}

	Turret Upgrade(){
		Vector3 oldpos = this.gameObject.transform.position;
		GameManager.selectedTurret = (GameObject)Instantiate(this.upgrade, oldpos, Quaternion.identity);
		GameManager.selectedScript = GameManager.selectedTurret.GetComponent<Turret>();
		Destroy(this.gameObject);
		return GameManager.selectedScript;
	}

	void OnGUI(){
		if (GameManager.selectedScript == this) {
			GUI.Box (new Rect (100, Screen.height - 100, Screen.width - 500, 100), GUIContent.none);
			if (GUI.Button(new Rect(110,Screen.height-90,100,50), "upgrade")) {
				if(this.upgrade != null){
				Upgrade ();
				}
			}
		}
	}
	
}