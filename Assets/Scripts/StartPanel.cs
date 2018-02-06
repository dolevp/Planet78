using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartPanel : MonoBehaviour {

	public Text scoreText, restartText, startText;
	public GameObject slider, money;
	public AttackManager aManager;
	// Use this for initialization
	void OnEnable () {




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
		money.SetActive (true);


	}



}
