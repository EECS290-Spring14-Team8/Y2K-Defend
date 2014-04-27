﻿using UnityEngine;
using System.Collections;

public class UnitSpawner : MonoBehaviour {
	public GameObject[] enemyUnits;
	public static int waveCompleted;
	public Transform target;
	private int numUnits;
	private float spawnRate;
	public static bool spawnReady;
	private float spawnTime;
	private int unit1Range;
	public static int spawned = 0;

	// Use this for initialization
	void Start () {
		numUnits = 10;
		unit1Range = 50;
	}
	
	// Update is called once per frame
	void Update () {
		if(numUnits <= 0){
			waveCompleted += 1;
			spawnReady = false;
			//this will need some testing
			numUnits += (int)waveCompleted*5 + 10;
			spawned += (int)waveCompleted*5 + 10;
			updateRandom();
		}
		if(spawned<=0)
			spawned =0;
		if(spawnReady){
			spawnUnit();
		}
	}
	void spawnUnit(){
		Debug.Log(spawned);
		int select;
		select = Random.Range(0,100);
		if(select < unit1Range){
			select = 0;
		}
		else{
			select = 1;
		}
		GameObject unit = (GameObject)Instantiate(enemyUnits[select],transform.position,transform.rotation);
		unit.GetComponent<AIPathFinder>().target = target;
		numUnits -= 1;
	}
	//updates the ranges for the different types of units
	void updateRandom(){
		if(unit1Range <=0 ){
			unit1Range = 1;
		}
		else{
			unit1Range -= 5;
		}
	}
}
