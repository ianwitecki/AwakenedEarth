using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiverScript : MonoBehaviour {

	private Rigidbody rgb;
	private Transform transform;
	public float moveSpeed;
	public float fallingSpeed;
	public float breakSpeed;


	// Use this for initialization
	void Start () {
		rgb = GetComponent<Rigidbody> ();
		transform = GetComponent<Transform> ();
		moveSpeed = 10f;
		fallingSpeed = -15f;
		breakSpeed = 5f;
	}

	// Update is called once per frame
	void Update () {
		float inputX = Input.GetAxis ("Horizontal");
		float inputY = Input.GetAxis ("Vertical");
		bool inputSpace = Input.GetButton ("Dive");

		rgb.velocity = (transform.forward * inputY * Time.deltaTime * 1000) + (transform.up * fallingSpeed);
		//print ("HELLOOO");
		if (inputSpace) {
			print("space");
			rgb.velocity = rgb.velocity + (transform.up * breakSpeed);
		}

		if (inputX != 0) {
			print ("HELLOOO");
			transform.Rotate (Vector3.up * inputX);
		}
	}
}



