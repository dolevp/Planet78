using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Earth : MonoBehaviour {

	public int health = 8;
	public Slider healthSlider;
	public Image sliderImage;
	public GameObject panel;
	public AttackManager aManager;
	public StartPanel sPanel;
	public Text bestText;
	// Use this for initialization
	void Awake () {

		PlayerPrefs.SetInt ("Score", 0);
	}

	void OnCollisionEnter(Collision col){

		health--;
		healthSlider.value--;
		if (health <= 2)
			sliderImage.color = Color.red;
		
		if (health <= 0) {
			//Explode
			aManager.gameOver = true;
			sPanel.RestartGame ();
			gameObject.SetActive(false);
		
			Time.timeScale = 0;
			panel.SetActive (true);

			PlayerPrefs.SetInt ("Score", aManager.score);

			if (PlayerPrefs.GetInt ("Score") > PlayerPrefs.GetInt("Best"))
				PlayerPrefs.SetInt ("Best", PlayerPrefs.GetInt ("Score"));
			

		}
	}
	

}
