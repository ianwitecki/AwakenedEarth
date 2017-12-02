using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class CaveGenerator : MonoBehaviour {

	private GameObject caveTorus;

	int tunnelDepth = 100;

	// Use this for initialization
	void Start () {
	
		caveTorus = Resources.Load<GameObject> ("Prefabs/CaveTorus");

		GenerateCave ();

	}

	void GenerateCave() {

		for (int y = 0; y < tunnelDepth; y+=5) {

			float x = Mathf.PerlinNoise(y/40f, 0) * 10f;
			float z = Mathf.PerlinNoise(y/40f, 0) * 10f; 


			Instantiate (caveTorus, new Vector3 (x, y, z), Quaternion.identity);

		}

	}	

}
