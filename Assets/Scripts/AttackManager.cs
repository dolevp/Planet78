using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackManager : MonoBehaviour {


	public GameObject asteroidPrefab;
	public GameObject newAsteroid;
	public GameObject oldAsteroid;
	public Transform earth;
	public float intervalBetweenAttacks = 2f;
	bool isAttacking = false;

	// Use this for initialization
	void Start () {
		


	}
	
	// Update is called once per frame
	void Update () {


		if (!isAttacking)
			StartCoroutine (Attack ());


		
	}

	IEnumerator Attack(){

		isAttacking = true;

		int randX = Random.Range (-7, 9);
		int randY = Random.Range (-4, 10);
		int randZ = Random.Range (-10, 9);

		Vector3 spawnPosition = new Vector3 (randX, randY, randZ);

		newAsteroid = Instantiate (asteroidPrefab, spawnPosition, Quaternion.identity);
		oldAsteroid = newAsteroid;
		Asteroid asteroid = newAsteroid.GetComponent<Asteroid> ();
		asteroid.earth = earth;
		Physics.IgnoreCollision(newAsteroid.GetComponent<SphereCollider>(),oldAsteroid.GetComponent<SphereCollider>());

//		navAgent = newAsteroid.GetComponent<NavMeshAgent> ();
//		navAgent.SetDestination (earth.position);

		yield return new WaitForSeconds (intervalBetweenAttacks);

		isAttacking = false;


	}
}
