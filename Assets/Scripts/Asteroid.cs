using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {

	public GameObject newExplosion, newRocket, rocketPrefab;
	public bool hasBeenDestroyed;
	public GameObject explosionEffect, smokeEffect;
	public float movementSpeed = 0.7f;
	public Transform earth, spawnPosition;
	public AttackManager aManager;
	// Use this for initialization
	void OnEnable () {

		hasBeenDestroyed = false;
	}

	void OnCollisionEnter(Collision col){

		movementSpeed += aManager.score / 45;

		if (col.gameObject.tag == "Earth") {


			Destroy (Instantiate (explosionEffect, transform.position, Quaternion.identity), 1);

			Instantiate (smokeEffect, transform.position, Quaternion.identity);

			Destroy (gameObject);
			hasBeenDestroyed = true;
//			StartCoroutine (WaitAndDestroy ());



		}

	}

	void OnMouseDown(){

		newRocket = Instantiate (rocketPrefab, spawnPosition.position, rocketPrefab.transform.rotation);
		//set the target variable
		newRocket.GetComponent<Rocket> ().rocketTarget = transform;
		//set the explosion effect variable
		newRocket.GetComponent<Rocket> ().explosionPrefab = explosionEffect;
		//set attackmanager variable
		newRocket.GetComponent<Rocket>().aManager = aManager;


	}

	// Update is called once per frame
	void Update () {

		if (earth != null)
			transform.position = Vector3.MoveTowards (transform.position, earth.position, movementSpeed * Time.deltaTime);
		else
			Destroy (gameObject);


	}

	/*IEnumerator WaitAndDestroy(){

		yield return new WaitForSeconds (3.5f);
		Destroy (newExplosion);

	}*/
}
