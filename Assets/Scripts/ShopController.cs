using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour {


	public Button[] purchaseButtons;

	// Use this for initialization
	void Start () {

		PlayerPrefs.SetInt ("Score", 50000);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PurchaseItem(int cost, int loc, string name){

		if (PlayerPrefs.GetInt (name) == 0) {
			PlayerPrefs.SetInt ("Score", PlayerPrefs.GetInt ("Score") - cost);
			PlayerPrefs.SetInt (name, 1);
			PlayerPrefs.SetString ("Equipped", name);
			purchaseButtons [loc].GetComponentInChildren<Text> ().text = "equipped";

		} else {

			PlayerPrefs.SetString ("Equipped", name);
			purchaseButtons [loc].GetComponentInChildren<Text> ().text = "equipped";

		}


	}


}
