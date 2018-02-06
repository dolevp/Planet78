using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Earth : MonoBehaviour {

	public int health = 8;
	public Slider healthSlider;
	public Image sliderImage;
	public AttackManager aManager;
	public bool damaged = false;
	public Image hitImage, fadeImage;
	public Color flashColor;
	public float flashSpeed = 3f;
	public Animator anim;
	private float fadeTime;
	public LevelManager lManager;
	public PlanetObject[] planets;
	public int currentPlanet = 0;
	// Use this for initialization
	void Awake(){


		Instantiate (planets [currentPlanet]);
		Destroy (gameObject);


		
	}

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



		



			aManager.gameOver = true;


		
//			Time.timeScale = 0;


			PlayerPrefs.SetInt ("Score", aManager.score);

			if (PlayerPrefs.GetInt ("Score") > PlayerPrefs.GetInt ("Best")) {
				PlayerPrefs.SetInt ("Best", PlayerPrefs.GetInt ("Score"));

			}
			

			lManager.BackToMenu ();
		}
	}




	

}
