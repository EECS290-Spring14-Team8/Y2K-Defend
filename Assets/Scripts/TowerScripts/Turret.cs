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
	public bool Commanded = false;
	
	// Use this for initialization
	void Start () {
		
	}
	
	public void shoot() {
		if (Time.time > timeTillNextAtt) {
			try{
				target.gameObject.GetComponent<Dude>().takeDamage(this.Power);
				timeTillNextAtt = Time.time + attackspeed;
				
				//muzzleflash
				GameObject clone = (GameObject)Instantiate(muzzFlash, turret.transform.position, turret.transform.localRotation);
				Destroy(clone,0.02f);
				
				audio.Play();
			}
			catch(System.Exception e){
				retarget();
			}
		}
	}
	
	public void retarget() {
		GameObject[] dudes = GameObject.FindGameObjectsWithTag("Enemy");
		foreach(GameObject x in dudes) {
			if (x != null) {
				float d = Vector3.Distance(this.gameObject.transform.position, x.transform.position);
				if (d < range) {
					target = x;
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
		GameManager.selectedTurret.tag = "tower";
		Destroy(this.gameObject);
		return GameManager.selectedScript;
	}
	
	void SellTower(){
		if (GameManager.selectedScript.name.Equals ("Basic1(Clone)")) 
			Money.adjustMoneyAmount (90);
		if (GameManager.selectedScript.name.Equals ("Basic2(Clone)"))
			Money.adjustMoneyAmount (150);
		if (GameManager.selectedScript.name.Equals ("Basic3(Clone)"))
			Money.adjustMoneyAmount (210);
		if (GameManager.selectedScript.name.Equals ("FireWall(Clone)"))
			Money.adjustMoneyAmount (180);
		if (GameManager.selectedScript.name.Equals ("FireWall2(Clone)"))
			Money.adjustMoneyAmount (240);
		if (GameManager.selectedScript.name.Equals ("Commander1(Clone)"))
			Money.adjustMoneyAmount (600);
		if (GameManager.selectedScript.name.Equals ("Commander2(Clone)"))
			Money.adjustMoneyAmount (660);
		if (GameManager.selectedScript.name.Equals ("honeypot(Clone)"))
			Money.adjustMoneyAmount (300);
		if (GameManager.selectedScript.name.Equals ("honeypot2(Clone)"))
			Money.adjustMoneyAmount (360);
		if (GameManager.selectedScript.name.Equals ("honeypot3(Clone)"))
			Money.adjustMoneyAmount (420);
		Debug.Log (GameManager.selectedScript.name);
		Destroy (this.gameObject);
	}
	
	void OnGUI(){
		if (!UnitSpawner.spawnReady && UnitSpawner.spawned == 0) {
			if (GameManager.selectedScript == this) {
				GUI.Box (new Rect (100, Screen.height - 70, 240, 100), GUIContent.none);
				if (this.upgrade != null) {
					if (Money.getMoneyAmount () < 100)
						GUI.Button (new Rect (110, Screen.height - 60, 100, 50), "Insufficient\nGold!");
					else {
						if (GUI.Button (new Rect (110, Screen.height - 60, 100, 50), "Upgrade\n(100 Gold)")) {
							Money.adjustMoneyAmount (-100);
							Upgrade ();
						}
					}
				} else {
					GUI.Button (new Rect (110, Screen.height - 60, 100, 50), "Cannot be\nupgraded");
				}
				if(GUI.Button (new Rect(230, Screen.height - 60, 100, 50), "Sell Back"))
					SellTower();
			}
			
		}
	}
	
}