using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds.Api;

public class AdManager : MonoBehaviour {

	public string appID = "ca-app-pub-6666466886819761~6891740827";
	public string cashVideoId = "ca-app-pub-6666466886819761/7942287983";
	public Animator cashAnim;
	public Text cashText;
	public InterstitialAd inter;
	// Use this for initialization
	void Start () {

		RequestInterstitial ();
		DontDestroyOnLoad (gameObject);
		MobileAds.Initialize (appID);

	}

	public void RequestInterstitial(){

//		string adUnitId = "ca-app-pub-6666466886819761/3873505875";
		string testUnitId = "ca-app-pub-3940256099942544/1033173712";

		inter = new InterstitialAd (testUnitId);
		AdRequest request = new AdRequest.Builder ().Build ();
		inter.LoadAd (request);



	}

	public void ShowInterstitial(){


		if (inter.IsLoaded())
			inter.Show ();
	}
	
	// Update is called once per frame

}
