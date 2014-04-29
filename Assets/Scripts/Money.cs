using UnityEngine;
using System.Collections;

public class Money : MonoBehaviour {

	//the amount of money the player currently has
	public static int amount;
	//the amount the player starts off with, can change depending on level, or difficulty
	int startingAmount;
	// Use this for initialization

	void Start () {
		startingAmount = 500;
		amount = startingAmount;
	}
	
	public static int getMoneyAmount(){
		return amount;
	}

	public static void adjustMoneyAmount(int adj) {
		amount += adj;
	}

}
