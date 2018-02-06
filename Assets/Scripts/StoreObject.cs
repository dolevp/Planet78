using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreObject : MonoBehaviour {


	public LevelManager lManager;
	public ShopController sController;
	public int planetNumber;

	public Text cost,planetName;
	public Image image;
	// Use this for initialization
	void Start () {

		SetObject ();
	}

	void SetObject(){


		planetName.text = sController.corePlanets [planetNumber].name;
		cost.text = "" + sController.corePlanets [planetNumber].cost;
		image.sprite = sController.corePlanets [planetNumber].howLooks;

	}


	public void PurchaseItem(){

		if (PlayerPrefs.GetInt ("Cash") >= sController.corePlanets [planetNumber].cost && PlayerPrefs.GetInt(planetName) == 0) {

			PlayerPrefs.SetInt ("Cash", PlayerPrefs.GetInt ("Cash") - sController.corePlanets [planetNumber].cost);
			lManager.planetNumber = planetNumber;
		}
		if (PlayerPrefs.GetInt (planetName) == 1)
			lManager.planetNumber = planetNumber;




	}


}
