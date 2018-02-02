using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Earth : MonoBehaviour {

	public int health = 8;
	public Slider healthSlider;
	public Image sliderImage;
	// Use this for initialization
	void Start () {
		
	}

	void OnCollisionEnter(Collision col){

		health--;
		healthSlider.value--;
		if (health <= 2)
			sliderImage.color = Color.red;
		
		if (health <= 0)
			//Explode
			Destroy(gameObject);
		

	}
	
	// Update is called once per frame
	void Explode () {
		
	}
}
