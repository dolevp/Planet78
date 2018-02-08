using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms;
using GooglePlayGames;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {


	public Image fadeImage;
	public Animator anim;




	void Start(){

		fadeImage = GameObject.Find ("BlackImage").GetComponent<Image>();
		anim = fadeImage.GetComponent<Animator> ();


	}
	IEnumerator FadeToMenu(){

		anim.SetBool ("Fade", true);
		anim.Play ("fadeOut");

		yield return new WaitUntil (() => fadeImage.color.a == 1);
		SceneManager.LoadScene (0);


	}

	IEnumerator FadeToGame(){

		anim.SetBool ("Fade", true);
		yield return new WaitUntil (() => fadeImage.color.a == 1);
		SceneManager.LoadScene (1);


	}

	IEnumerator FadeToShop(){

		anim.SetBool ("Fade", true);
		yield return new WaitUntil (() => fadeImage.color.a == 1);
		SceneManager.LoadScene (2);


	}

	public void GoLeaderboard(){


		Social.localUser.Authenticate((bool success) => {
			// handle success or failure

			if(success)
				Social.ShowLeaderboardUI ();
		});
		


	}

	public void GoAchievements(){

		Social.localUser.Authenticate((bool success) => {
			// handle success or failure

			if(success)
				Social.ShowAchievementsUI ();

		});
		


	}

	public void GameOverAd(){



	}

	public void BackToMenu(){

		StartCoroutine(FadeToMenu());

	}

	public void GoToGame(){

		StartCoroutine(FadeToGame());

	}

	public void GoShopping(){


		StartCoroutine(FadeToShop());
	}
}
