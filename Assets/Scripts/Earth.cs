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
	public bool damaged = false;
	public Image hitImage;
	public Color flashColor;
	public float flashSpeed = 3f;
	public Fading fadeObject;
	private float fadeTime;
	// Use this for initialization
	void Update () {

		if (damaged) {



			hitImage.color = flashColor;

		} else {

			hitImage.color = Color.Lerp (hitImage.color, Color.clear, flashSpeed * Time.deltaTime);

		}

		damaged = false;
	}

	void OnCollisionEnter(Collision col){

		damaged = true;
		health--;
		healthSlider.value--;
		if (health <= 2)
			sliderImage.color = Color.red;
		
		if (health <= 0) {
			//Explode
			fadeTime = fadeObject.BeginFade (-1);
			StartCoroutine (WaitFade ());
			sPanel.RestartGame ();


			aManager.gameOver = true;


		
			Time.timeScale = 0;
			panel.SetActive (true);

			PlayerPrefs.SetInt ("Score", aManager.score);

			if (PlayerPrefs.GetInt ("Score") > PlayerPrefs.GetInt ("Best")) {
				PlayerPrefs.SetInt ("Best", PlayerPrefs.GetInt ("Score"));

			}
			



		}
	}

	IEnumerator WaitFade(){

		yield return new WaitForSeconds (fadeTime + 2f);

	}
	

}
