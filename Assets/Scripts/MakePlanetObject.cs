using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MakePlanetObject{

	[MenuItem ("Assets/Create/Planet")]
	public static void Create(){


		PlanetObject asset = ScriptableObject.CreateInstance<PlanetObject> ();
		AssetDatabase.CreateAsset (asset, "Assets/NewPlanetObject.asset");
		AssetDatabase.SaveAssets ();
		EditorUtility.FocusProjectWindow ();
		Selection.activeObject = asset;


	}

}
