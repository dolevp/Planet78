﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class AttackManager : MonoBehaviour {


	public GameObject fireEffect, newFire, smallExplosion;
	public GameObject asteroidPrefab, smokeEffect;
	public GameObject newAsteroid;
	public GameObject oldAsteroid;
	public Transform earth, rocketSpawn;
	public float intervalBetweenAttacks = 5f;
	bool isAttacking = false;
	public Text scoreText, bestText;
	public bool gameOver = false;

	// Use this for initialization
	void Start () {




	}
	
	// Update is called once per frame
	void Update () {


		if (!isAttacking)
			StartCoroutine (Attack ());



		
	}

	public void AddScore(){



		PlayerPrefs.SetInt ("Score", PlayerPrefs.GetInt("Score") + 1);
		scoreText.text = "score: " + PlayerPrefs.GetInt("Score");
		intervalBetweenAttacks -= PlayerPrefs.GetInt ("Score") / 92;
		if (PlayerPrefs.GetInt ("Score") > PlayerPrefs.GetInt("Best"))
			PlayerPrefs.SetInt ("Best", PlayerPrefs.GetInt ("Score"));
		bestText.text = "best: " + PlayerPrefs.GetInt ("Best").ToString();


	}

	IEnumerator Attack(){

		if (!gameOver) {
			isAttacking = true;

			int randX = Random.Range (-10, 12);
			int randY = Random.Range (5, 15);
			int randZ = Random.Range (-9, -13);

			Vector3 spawnPosition = new Vector3 (randX, randY, randZ);

			newAsteroid = Instantiate (asteroidPrefab, spawnPosition, Quaternion.identity);
			oldAsteroid = newAsteroid;
			Asteroid asteroid = newAsteroid.GetComponent<Asteroid> ();
			newFire = Instantiate (fireEffect, newAsteroid.transform.position, Quaternion.identity);
			newFire.transform.SetParent (newAsteroid.transform);
			//set asteroid variables
			asteroid.earth = earth;
			asteroid.spawnPosition = rocketSpawn;
			asteroid.explosionEffect = smallExplosion;
			asteroid.smokeEffect = smokeEffect;
			asteroid.aManager = GetComponent<AttackManager> ();
			//end
			Physics.IgnoreCollision (newAsteroid.GetComponent<SphereCollider> (), oldAsteroid.GetComponent<SphereCollider> ());

//		navAgent = newAsteroid.GetComponent<NavMeshAgent> ();
//		navAgent.SetDestination (earth.position);

			yield return new WaitForSeconds (intervalBetweenAttacks);

			isAttacking = false;


		} 


	}
}
