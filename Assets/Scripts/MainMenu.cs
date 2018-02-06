using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour {


	public Text bestText;
	public int score;
	public Text scoreText;

	void Awake(){

		bestText.text = "" + PlayerPrefs.GetInt ("Best");
		scoreText.text = "" +  PlayerPrefs.GetInt ("Score");
	}
	public void StartGame(){

		SceneManager.LoadScene (1);

	}

	public void Leaderboard(){


	}
}
