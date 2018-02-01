using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {

	public GameObject newExplosion;
	public GameObject explosionEffect, smokeEffect;
	public float movementSpeed = 0.7f;
	public Transform earth;
	public AttackManager aManager;
	// Use this for initialization
	void Start () {

	}

	void OnCollisionEnter(Collision col){

		if (col.gameObject.tag == "Earth") {


			newExplosion = Instantiate (explosionEffect, transform.position, Quaternion.identity);
			Instantiate (smokeEffect, transform.position, Quaternion.identity);

			Destroy (gameObject);
			StartCoroutine (WaitAndDestroy ());



		}

	}
	
	// Update is called once per frame
	void Update () {

		transform.position = Vector3.MoveTowards(transform.position, earth.position, movementSpeed * Time.deltaTime);
	}

	IEnumerator WaitAndDestroy(){

		yield return new WaitForSeconds (3.5f);
		Destroy (newExplosion);

	}
}
