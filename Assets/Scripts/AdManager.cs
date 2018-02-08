using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds.Api;

public class AdManager : MonoBehaviour {


	public string appId;
	public string InterID;
	public InterstitialAd interstitial;
	public RewardBasedVideoAd rewardVideo;
	public Text cashText;
	public Animator cashAnim;
	// Use this for initialization
	void Start () {

		DontDestroyOnLoad (gameObject);

		appId = "ca-app-pub-6666466886819761~6891740827";



		MobileAds.Initialize (appId);

		this.rewardVideo = RewardBasedVideoAd.Instance;

		rewardVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;

		this.RequestVideo ();

		RequestInter ();

	}
	
	// Update is called once per frame
	void RequestInter () {

		InterID = "ca-app-pub-6666466886819761/3873505875";

		interstitial = new InterstitialAd(InterID);
		// Create an empty ad request.
		AdRequest request = new AdRequest.Builder().Build();
		// Load the interstitial with the request.
		interstitial.LoadAd(request);
	}

	public void ShowInter(){

		if (interstitial.IsLoaded()) {
			interstitial.Show();
		}
	}

	public void HandleRewardBasedVideoRewarded(object sender, Reward args)
	{
		string type = "Cash";
		double amount = 35.0f;
		MonoBehaviour.print(
			"User rewarded with: "
			+ amount.ToString() + " " + type);

		PlayerPrefs.SetInt ("Cash", PlayerPrefs.GetInt ("Cash") + 35);
		cashAnim.Play ("GetCashFromAd");
		cashText.text = "" + PlayerPrefs.GetInt ("Cash");
	}

	private void RequestVideo(){



					 

		// Create an empty ad request.
		AdRequest request = new AdRequest.Builder().Build();
		// Load the rewarded video ad with the request.
		this.rewardVideo.LoadAd(request, "ca-app-pub-6666466886819761/7942287983"
		);

	}

	public void ShowVideo(){

		if (rewardVideo.IsLoaded ())
			rewardVideo.Show ();
	
			
	}


}
