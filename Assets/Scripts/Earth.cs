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
	// Use this for initialization
	void Start () {

		PlayerPrefs.SetInt ("Score", 0);
	}

	void OnCollisionEnter(Collision col){

		health--;
		healthSlider.value--;
		if (health <= 2)
			sliderImage.color = Color.red;
		
		if (health <= 0) {
			//Explode
			PlayerPrefs.SetInt("GameOver", 1);
			gameObject.SetActive(false);
		
			Time.timeScale = 0;
			panel.SetActive (true);

		}
	}
	

}
