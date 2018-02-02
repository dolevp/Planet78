using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Earth : MonoBehaviour {

	public Slider healthSlider;
	public GameObject fillColor;
	// Use this for initialization
	void Start () {
		
	}

	void OnCollisionEnter(Collision col){

		healthSlider.value--;
		if(healthSlider.value <=3)
			fillColor.

	}
	
	// Update is called once per frame
	void Explode () {
		
	}
}
