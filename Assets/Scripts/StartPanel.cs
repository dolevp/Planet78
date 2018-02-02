﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartPanel : MonoBehaviour {

	public Text scoreText, restartText, startText, scoreFinishedText;
	public GameObject slider;
	public AttackManager aManager;
	public GameObject earth;
	// Use this for initialization
	void OnEnable () {

		aManager.bestText.text = "best: " + PlayerPrefs.GetInt ("Best").ToString();

		if(PlayerPrefs.GetInt("Score") > 0)
			scoreFinishedText.text = "score: " + PlayerPrefs.GetInt("Score");
		Time.timeScale = 0;
		aManager.gameObject.SetActive (false);

			
	}
	
	// Update is called once per frame
	void Update () {

	
		
		if(Input.GetMouseButtonDown(0)){

			if (!aManager.gameOver)
				StartGame ();
			
				


		}
	}

	IEnumerator WaitABit(){

		yield return new WaitForSeconds (4.5f);

	}

	public void StartGame(){


		gameObject.GetComponent<Image> ().color = Color.Lerp (gameObject.GetComponent<Image> ().color, new Color (60, 60, 60, 2), 0.3f * Time.deltaTime);
		StartCoroutine (WaitABit ());
		gameObject.SetActive (false);
		scoreText.gameObject.SetActive (true);
		slider.SetActive (true);
		Time.timeScale = 1;
		aManager.gameObject.SetActive (true);



	}

	public void RestartGame(){

		SceneManager.LoadScene (0);
		restartText.gameObject.SetActive (true);
		startText.gameObject.SetActive (false);






	}

}
