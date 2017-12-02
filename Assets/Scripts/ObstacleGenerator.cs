using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class CaveGenerator : MonoBehaviour {

    //Rock Prefabs
    private GameObject rock1;
    private GameObject rock2;
    private GameObject rock3;
    private GameObject rock4;
    private GameObject rock5;


    //List of Rock Obstacles
    private List<GameObject> obstacles;

    void ObstacleGenerate(float _x, float _y, float _z) {
        int rockChoice = Random.Range(0, 5);
        GameObject rock = obstacles[rockChoice];

        float theta = Random.Range(0, 2 * Mathf.PI); //angle to instantiate rock at 

        //Spot against wall to Instantiate object at
        float x_wall = Mathf.Cos(theta) * radius;  
        float z_wall = Mathf.Sin(theta) * radius;

        Quaternion rotation = Quaternion.identity;

        rotation.eulerAngles = new Vector3(0, (theta*180f)/Mathf.PI , 0);
        Instantiate(rock, new Vector3(_x + x_wall, _y, _z + z_wall), rotation);
        



    }

}
