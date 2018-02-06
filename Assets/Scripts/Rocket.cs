using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {


	public GameObject explosionPrefab;
	public Transform rocketTarget;
	public AttackManager aManager;

	// Use this for initialization


	void OnCollisionEnter (Collision col){

		Destroy (Instantiate (explosionPrefab, transform.position, Quaternion.identity), 2.3f);
		Destroy (col.gameObject);
		Destroy (gameObject);
		aManager.AddScore ();
		aManager.AddCash ();
		//play add cash animation

	}
	// Update is called once per frame
	void Update () {

		if (rocketTarget != null)
			transform.position = Vector3.MoveTowards (transform.position, rocketTarget.position, 4.6f * Time.deltaTime);
		else
			Destroy (gameObject);

	}
}
