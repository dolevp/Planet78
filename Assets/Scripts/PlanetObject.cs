using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PlanetObject : ScriptableObject {

	public string planetName = "Name Here";
	public int cost;
	public Image howLooks;
	public Mesh mesh;

}
