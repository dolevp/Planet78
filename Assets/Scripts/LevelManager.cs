using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {


	public Image fadeImage;
	public Animator anim;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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

	public void BackToMenu(){

		StartCoroutine(FadeToMenu());

	}

	public void GoToGame(){

		StartCoroutine(FadeToGame());

	}
}
