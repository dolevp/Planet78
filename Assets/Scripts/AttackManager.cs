using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using GooglePlayGames;
using UnityEngine.SocialPlatforms; 

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
	public Color[] backgroundColors;
	int colorIndex = 0;
	public Camera cam;

	void Awake(){

		cashText.text = "" + PlayerPrefs.GetInt ("Cash");


	}

	void Start () {


		score = 0;
		cam.clearFlags = CameraClearFlags.SolidColor;


	}
	
	// Update is called once per frame
	void Update () {


		if (!isAttacking)
			StartCoroutine (Attack ());

		cam.backgroundColor = Color.Lerp (cam.backgroundColor, backgroundColors [colorIndex], 1.1f * Time.deltaTime);

		
	}

	public void AddScore(){


		score++;

		scoreText.text = "score: " + score;
		intervalBetweenAttacks -= score / 92;

		if(score % 25 == 0) {
			
			colorIndex++;


		}
		if (colorIndex == backgroundColors.Length - 1)
			colorIndex = 0;
		
		if (score >= 50)
			Social.ReportProgress ("CgkI1KCwvoQTEAIQAg", 100.0f, (bool success) => {


			});

		if (score >= 100)
			Social.ReportProgress ("CgkI1KCwvoQTEAIQAw", 100.0f, (bool success) => {


			});

		if (score >= 200)
			Social.ReportProgress ("CgkI1KCwvoQTEAIQBA", 100.0f, (bool success) => {


			});
		if (score >= 500)
			Social.ReportProgress ("CgkI1KCwvoQTEAIQBQ", 100.0f, (bool success) => {


			});

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
