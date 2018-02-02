using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPanel : MonoBehaviour {

	public Text scoreText;
	public GameObject slider;
	// Use this for initialization
	void Start () {

		Time.timeScale = 0;
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetMouseButtonDown(0)){


			gameObject.GetComponent<Image> ().color = Color.Lerp (gameObject.GetComponent<Image> ().color, new Color (60, 60, 60, 2), 0.3f * Time.deltaTime);
			StartCoroutine (WaitABit ());
			gameObject.SetActive (false);
			scoreText.gameObject.SetActive (true);
			slider.SetActive (true);
			Time.timeScale = 1;

		}
	}

	IEnumerator WaitABit(){

		yield return new WaitForSeconds (4.5f);

	}
}
