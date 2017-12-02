using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class CaveGenerator : MonoBehaviour {

	private GameObject caveTorus;

	int tunnelDepth = 100;

    private float radius;

	// Use this for initialization
	void Start () {
        
        // Instantiate Rock Obstacles
        rock1 = Resources.Load<GameObject>("Prefabs/rock1");
        rock2 = Resources.Load<GameObject>("Prefabs/rock2");
        rock3 = Resources.Load<GameObject>("Prefabs/rock3");
        rock4 = Resources.Load<GameObject>("Prefabs/rock4");
        rock5 = Resources.Load<GameObject>("Prefabs/rock5");

        obstacles = new List<GameObject> { rock1, rock2, rock3, rock4, rock5 };

        caveTorus = Resources.Load<GameObject> ("Prefabs/CaveCylinder");

        radius = 5;

		GenerateCave ();

	}

	void GenerateCave() {
        
        int obstacleFreq = 2;

		for (int y = 0; y < tunnelDepth; y+=5) {

			float x = Mathf.PerlinNoise(y/7f, 0) * 10f;
			float z = Mathf.PerlinNoise(y/7f, 0) * 10f;

            //Create Walls
            Instantiate (caveTorus, new Vector3 (x, y, z), Quaternion.identity);



            //Create Obstacles
            if (obstacleFreq == 0)
            {
                ObstacleGenerate(x, y, z);
                obstacleFreq = 2;
            } else
            {
                obstacleFreq -= 1;
            }

		}

	}	

}
