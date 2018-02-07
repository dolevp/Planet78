using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class PlayServicesManager : MonoBehaviour {




	// Use this for initialization
	void Awake () {

		PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
			// enables saving game progress.
			.EnableSavedGames()
			.RequestIdToken()
			.Build();

		PlayGamesPlatform.InitializeInstance(config);
		// recommended for debugging:
		PlayGamesPlatform.DebugLogEnabled = true;
		// Activate the Google Play Games platform
		PlayGamesPlatform.Activate();

		Social.localUser.Authenticate((bool success) => {
			// handle success or failure
		});


	}



	

}
