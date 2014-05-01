using UnityEngine;
using System.Collections;

public class Commander2Glow : MonoBehaviour {
	public Material thisMat;
	private float time = 0.0f;
	public float interpolationPeriod = 5.0f;
	private int cycle = 1;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		
		if (time >= interpolationPeriod) {
			time = 0.0f;
			
			switch (cycle) {
			case 1: 
				thisMat.color = Color.red;
				break;
			case 2:
				thisMat.color = Color.yellow;
				break;
			case 3:
				thisMat.color = Color.green;
				break;
			case 4:
				thisMat.color = Color.blue;
				break;
			case 5:
				thisMat.color = Color.magenta;
				break;
			case 6:
				thisMat.color = Color.white;
				break;
			}
			cycle++;
			if (cycle == 7) cycle = 1;
		}
	}
}
