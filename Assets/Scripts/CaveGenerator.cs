using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class CaveGenerator : MonoBehaviour {

	private GameObject caveTorus;



    //Level Variables
    int tunnelDepth = 5000;
    int obstacleMinFreq;
    int obstacleMaxFreq;
    float doubleChance;
    float gapChance;
    int maxGapLength;


    private float radius;

	// Use this for initialization
	void Start () {
        obstacleMinFreq = 15;
        obstacleMaxFreq = 5;
        doubleChance = 5;
        gapChance = 5;
        maxGapLength = obstacleMinFreq + 10;
  
        // Instantiate Rock Obstacles
        rock1 = Resources.Load<GameObject>("Prefabs/rock1Parent");
        rock2 = Resources.Load<GameObject>("Prefabs/rock2Parent");
        rock3 = Resources.Load<GameObject>("Prefabs/rock3Parent");
        rock4 = Resources.Load<GameObject>("Prefabs/rock4Parent");
        rock5 = Resources.Load<GameObject>("Prefabs/rock5Parent");

        obstacles = new List<GameObject> { rock1, rock2, rock3, rock4, rock5 };

        caveTorus = Resources.Load<GameObject> ("Prefabs/CaveCylinder");

        radius = 7f;

		GenerateCave ();

	}

	void GenerateCave() {

        int obstacleFreq = obstacleMinFreq;
        bool onGap = false;


		for (int y = 0; y < tunnelDepth; y+=5) {

            float x = Mathf.PerlinNoise(y/25f, 0) * 6f;
            float z = Mathf.PerlinNoise(y/25f, 0) * 6f;
            System.Random rand = new System.Random();

            //Create Walls
            Instantiate (caveTorus, new Vector3 (x, y, z), Quaternion.identity);



            //Create Obstacles
            if (obstacleFreq == 0)
            {
                //Instantiate object of end gap
                if (!onGap)
                {
                    ObstacleGenerate(x, y, z);
                    if (rand.Next(100) <= doubleChance) ObstacleGenerate(x, y, z);

                } else
                {
                    Debug.Log("gap off");
                    onGap = false;
                }

                //Gap or obstacle countdown
                if (rand.Next(100) <= gapChance)
                {
                    Debug.Log("on gap");
                    onGap = true;
                    obstacleFreq = Random.Range(obstacleMaxFreq, maxGapLength);
                }
                else
                {
                    Debug.Log("on obstacle");
                    obstacleFreq = Random.Range(obstacleMaxFreq, obstacleMinFreq);
                }

            } else
            {
                obstacleFreq -= 1;
            }

		}

	}	

}
