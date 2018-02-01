using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackManager : MonoBehaviour {


	public GameObject fireEffect, newFire, smallExplosion;
	public GameObject asteroidPrefab, smokeEffect;
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

		int randX = Random.Range (-10, 12);
		int randY = Random.Range (5, 15);
		int randZ = Random.Range (-9, -13);

		Vector3 spawnPosition = new Vector3 (randX, randY, randZ);

		newAsteroid = Instantiate (asteroidPrefab, spawnPosition, Quaternion.identity);
		oldAsteroid = newAsteroid;
		Asteroid asteroid = newAsteroid.GetComponent<Asteroid> ();
		newFire = Instantiate (fireEffect, newAsteroid.transform.position, Quaternion.identity);
		newFire.transform.SetParent (newAsteroid.transform);
		asteroid.earth = earth;
		asteroid.explosionEffect = smallExplosion;
		asteroid.smokeEffect = smokeEffect;
		asteroid.aManager = GetComponent<AttackManager> ();
		Physics.IgnoreCollision(newAsteroid.GetComponent<SphereCollider>(),oldAsteroid.GetComponent<SphereCollider>());

//		navAgent = newAsteroid.GetComponent<NavMeshAgent> ();
//		navAgent.SetDestination (earth.position);

		yield return new WaitForSeconds (intervalBetweenAttacks);

		isAttacking = false;


	}
}
