using UnityEngine;
using System.Collections;

public class Commander1Glow : MonoBehaviour {
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
				thisMat.color = Color.green;
				break;
			case 3:
				thisMat.color = Color.white;
				break;
			}
			cycle++;
			if (cycle == 4) cycle = 1;
		}
	}
}
