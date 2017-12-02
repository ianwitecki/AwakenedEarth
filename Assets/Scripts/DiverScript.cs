using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiverScript : MonoBehaviour {

	private Rigidbody rgb;
	private Transform transform;
	public float moveSpeed;
	public float fallingSpeed;

	public bool sideways;

	int rotateSpeed = 50;


	// Use this for initialization
	void Start () {
		rgb = GetComponent<Rigidbody> ();
		transform = GetComponent<Transform> ();
		moveSpeed = 10f;
		fallingSpeed = -10f;
		sideways = false;
	}

	// Update is called once per frame
	void Update () {
		float inputX = Input.GetAxis ("Horizontal");
		float inputY = Input.GetAxis ("Vertical");

		bool inputSpace = Input.GetButton ("Jump");

		rgb.velocity = (transform.forward * inputY * Time.deltaTime * 1000) + (transform.up * fallingSpeed);

		if (inputSpace) {
			StartCoroutine (rotateDown ());
		}

		if (inputX != 0) {
			transform.Rotate (Vector3.up * inputX);
		}
	}

	IEnumerator rotateDown () {
		bool spaceInput = Input.GetButton ("Jump");

		if (spaceInput) {
			while (spaceInput && (transform.rotation.x > -90f)) {
				yield return new WaitForSeconds (0.01f);
				transform.Rotate (Vector3.left * Time.deltaTime * 2);
				spaceInput = Input.GetButton ("Jump");
			}
			StartCoroutine (rotateUp ());
		} else {
			yield return new WaitForSeconds (0f);
		}
	}

	IEnumerator rotateUp () {
		while (transform.rotation.x < 0) {
			yield return new WaitForSeconds (0.01f);
			transform.Rotate (Vector3.right * Time.deltaTime * 2);
		}
	}
}

