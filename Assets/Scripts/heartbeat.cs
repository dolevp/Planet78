using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heartbeat : MonoBehaviour {

	public Earth earth;
	public Animator anim;
	// Use this for initialization
	void Start(){

		anim = GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {

		anim.speed += 0.006f * Time.deltaTime;
	}
}
