using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartPanel : MonoBehaviour {

	public Text scoreText;
	public GameObject slider;
	public AttackManager aManager;
	public GameObject earth;
	// Use this for initialization
	void Start () {

		Time.timeScale = 0;
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetMouseButtonDown(0)){

			if (!aManager.gameOver)
				StartGame ();
			else
				RestartGame ();


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



	}

	public void RestartGame(){

		aManager.gameOver = false;
		gameObject.GetComponent<Image> ().color = Color.Lerp (gameObject.GetComponent<Image> ().color, new Color (60, 60, 60, 2), 0.3f * Time.deltaTime);
		earth.SetActive (true);
		earth.GetComponent<Earth> ().health = 8;
		earth.GetComponent<Earth> ().healthSlider.value = earth.GetComponent<Earth> ().healthSlider.maxValue;
		StartCoroutine (WaitABit ());
		gameObject.SetActive (false);
		scoreText.gameObject.SetActive (true);
		slider.SetActive (true);
		Time.timeScale = 1;
		aManager.score = 0;
		aManager.scoreText.text = "score: " + aManager.score;


	}
}
