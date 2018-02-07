using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class AttackManager : MonoBehaviour {


	public GameObject fireEffect, newFire;
	public GameObject asteroidPrefab;
	public GameObject newAsteroid;
	public GameObject oldAsteroid;
	public Transform earth, rocketSpawn;
	float intervalBetweenAttacks = 2.1f;
	bool isAttacking = false;
	public Text scoreText, cashText;
	public bool gameOver = false;
	public int score = 0;
	public Animator cashAnim;

	void Awake(){

		cashText.text = "" + PlayerPrefs.GetInt ("Cash");


	}

	void Start () {


		score = 0;


	}
	
	// Update is called once per frame
	void Update () {


		if (!isAttacking)
			StartCoroutine (Attack ());



		
	}

	public void AddScore(){


		score++;

		scoreText.text = "score: " + score;
		intervalBetweenAttacks -= score / 92;



	}

	public void AddCash(){

		PlayerPrefs.SetInt ("Cash", PlayerPrefs.GetInt ("Cash") + 1);
		cashText.text = "" + PlayerPrefs.GetInt ("Cash");
		cashAnim.Play ("beat");
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
//			newFire = Instantiate (fireEffect, newAsteroid.transform.position, Quaternion.identity);
//			newFire.transform.SetParent (newAsteroid.transform);
			//set asteroid variables
			asteroid.earth = earth;
			asteroid.spawnPosition = rocketSpawn;
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
