using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {


	public float movementSpeed = 0.7f;
	public Transform earth;
	// Use this for initialization
	void Start () {
		
	}

	void OnCollisionEnter(Collision col){

		if (col.gameObject.tag == "Earth")
			Destroy (gameObject);

	}
	
	// Update is called once per frame
	void Update () {

		transform.position = Vector3.MoveTowards(transform.position, earth.position, movementSpeed * Time.deltaTime);
	}
}
