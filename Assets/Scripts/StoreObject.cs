using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using UnityEngine.Analytics;

public class StoreObject : MonoBehaviour {


	public LevelManager lManager;
	public ShopController sController;
	public int planetNumber;

	public Text cost,planetName, buttonText, cashText;
	public Image image;
	public AudioSource notEnough, purchase, equip;
	// Use this for initialization
	void Start () {


		SetObject ();

	}

	void SetObject(){

		buttonText.text = "purchase";

		if (PlayerPrefs.GetInt (sController.corePlanets [planetNumber].name) == 1)
			buttonText.text = "equip";
		
		if(PlayerPrefs.GetInt("Current") == planetNumber)
			//its this planet
			buttonText.text = "equipped";


		
		planetName.text = sController.corePlanets [planetNumber].name;
		cost.text = "" + sController.corePlanets [planetNumber].cost;
		image.sprite = sController.corePlanets [planetNumber].howLooks;

	}


	public void PurchaseItem(){
		

		if (PlayerPrefs.GetInt ("Cash") >= sController.corePlanets [planetNumber].cost && PlayerPrefs.GetInt (sController.corePlanets [planetNumber].name) == 0) {
			//buy this planet

			if (planetNumber != 0) {
				Social.ReportProgress ("CgkI1KCwvoQTEAIQAQ", 100.0f, (bool success) => {
					// handle success or failure
				});
			}
			if (planetNumber == 4) {

				Social.ReportProgress ("CgkI1KCwvoQTEAIQBg", 100.0f, (bool success) => {


				});

			}
				
	
			PlayerPrefs.SetInt ("Cash", PlayerPrefs.GetInt ("Cash") - sController.corePlanets [planetNumber].cost);
			PlayerPrefs.SetInt (sController.corePlanets [planetNumber].name, 1);
			PlayerPrefs.SetInt ("Current", planetNumber);

			Analytics.CustomEvent ("PurchasedPlanet" + planetName.text);

			purchase.Play ();

		}

		if (PlayerPrefs.GetInt ("Cash") < sController.corePlanets [planetNumber].cost && PlayerPrefs.GetInt (sController.corePlanets [planetNumber].name) == 0) {
			//not enough money, bruh!
			notEnough.Play();

		}
		//make sure to equip it
		if (PlayerPrefs.GetInt (sController.corePlanets [planetNumber].name) == 1) {
			
			PlayerPrefs.SetInt ("Current", planetNumber);

			Analytics.CustomEvent ("EquippedPlanet" + planetName.text);

			equip.Play ();
		}



		cashText.text = "" + PlayerPrefs.GetInt ("Cash");

	}

	void Update(){

		SetObject ();

	}


}
