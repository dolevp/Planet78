using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Earth : MonoBehaviour {

	public int health = 8;
	public Slider healthSlider;
	public Text restartText, startText, scoreFinishedText;
	public Image sliderImage;
	public GameObject panel;
	public AttackManager aManager;
	// Use this for initialization
	void Start () {
		
	}

	void OnCollisionEnter(Collision col){

		health--;
		healthSlider.value--;
		if (health <= 2)
			sliderImage.color = Color.red;
		
		if (health <= 0) {
			//Explode
			aManager.gameOver = true;
			gameObject.SetActive(false);
		
			Time.timeScale = 0;
			panel.SetActive (true);
			startText.text = "destroyed";
			restartText.gameObject.SetActive (true);
			scoreFinishedText.gameObject.SetActive (true);
			scoreFinishedText.text = "score: " + aManager.score;

		}
	}
	

}
