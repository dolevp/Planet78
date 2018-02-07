using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreObject : MonoBehaviour {


	public LevelManager lManager;
	public ShopController sController;
	public int planetNumber;

	public Text cost,planetName, buttonText;
	public Image image;
	// Use this for initialization
	void Start () {

		SetObject ();
	}

	void SetObject(){

		buttonText.text = "purchase";
		if (PlayerPrefs.GetInt (sController.corePlanets [planetNumber].name) == 1)
			buttonText.text = "equip";
		if(lManager.planetNumber == planetNumber)
			//its this planet
			buttonText.text = "equipped";
		planetName.text = sController.corePlanets [planetNumber].name;
		cost.text = "" + sController.corePlanets [planetNumber].cost;
		image.sprite = sController.corePlanets [planetNumber].howLooks;

	}


	public void PurchaseItem(){
		

		if (PlayerPrefs.GetInt ("Cash") >= sController.corePlanets [planetNumber].cost && PlayerPrefs.GetInt(sController.corePlanets[planetNumber].name) == 0) {

			PlayerPrefs.SetInt ("Cash", PlayerPrefs.GetInt ("Cash") - sController.corePlanets [planetNumber].cost);
			PlayerPrefs.SetInt (sController.corePlanets [planetNumber].name, 1);
			lManager.planetNumber = planetNumber;
		}
		if (PlayerPrefs.GetInt (sController.corePlanets [planetNumber].name) == 1)
			lManager.planetNumber = planetNumber;




	}


}
