using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fading : MonoBehaviour {

	public Texture2D fadeOutTexture;
	public float fadeSpeed = 0.8f;
	private int drawDepth = -1000;
	private float alpha = .8f;
	private int fadeDir = -1;
	// Use this for initialization
	void OnGUI () {

		alpha += fadeDir * fadeSpeed * Time.deltaTime;
		alpha = Mathf.Clamp01 (alpha);

		GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);
		GUI.depth = drawDepth;
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), fadeOutTexture);
	}

	public float BeginFade (int dir){

		fadeDir = dir;
		return(fadeSpeed);

	}


	void OnEnable(){

		SceneManager.sceneLoaded += OnLevelFinish;
	}

	void OnDisable(){

		SceneManager.sceneLoaded -= OnLevelFinish;
	}

	void OnLevelFinish(Scene scene, LoadSceneMode mode){

		BeginFade (-1);

	}



}
