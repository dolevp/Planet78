using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {


	public Image fadeImage;
	public int planetNumber;
	public Animator anim;



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
		SceneManager.LoadScene (3);


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
