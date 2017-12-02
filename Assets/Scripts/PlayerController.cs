using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Rigidbody diver;

    public float speed;
    public float health;
    public float headSize;
    public float diveSpeed;
    public float yStart;
    public Camera cam;

    private float height;
    private float wingspan;
    private float shoulderWidth;
    private Vector3 defaultScale;
    private bool isVertical;
    private BoxCollider boxCollide;


	// Use this for initialization
	void Start () {

        diver = GetComponent<Rigidbody>();
        boxCollide = GetComponent<BoxCollider>();

        Debug.Log("Initial z angle: " + diver.transform.eulerAngles);

        height = headSize * 8f;
        wingspan = headSize * 10.5f;
        shoulderWidth = headSize * 3f;

        defaultScale = new Vector3(height, headSize, wingspan);
        diver.transform.localScale = defaultScale;
        boxCollide.transform.localScale = defaultScale;
        diver.transform.position = Vector3.up * yStart;

        //cam.transform.position = Vector3.right * ((height / 2) - (headSize / 2));

        isVertical = false;

	}
	
	// Update is called once per frame
	void Update () {

        //cam.transform.position = diver.transform.position;
        //cam.transform.position = Vector3.right * ((height / 2) - (headSize / 2));


    }

    void FixedUpdate() {

        diver.transform.localScale = defaultScale;
        boxCollide.transform.localScale = defaultScale;
        DoInput(Time.deltaTime);

        Physics.gravity = diver.transform.up * -9.81f;

    }

    void DoInput(float t) {

        float side2side = Input.GetAxis("Horizontal");
        float front2back = Input.GetAxis("Vertical");
        bool dive = Input.GetButton("Dive");

        float xRotation = -side2side * speed;
        float zRotation = -front2back * speed;

        if (side2side != 0 && front2back != 0) {
            float angle = Mathf.PI / 4;
            xRotation *= Mathf.Cos(angle);
            zRotation *= Mathf.Sin(angle);
        }


      //      diver.AddTorque(new Vector3(xRotation, 0, zRotation) * t, ForceMode.Acceleration);
        diver.AddTorque(transform.right * xRotation * t, ForceMode.VelocityChange);
        diver.AddTorque(transform.forward * zRotation * t, ForceMode.VelocityChange);


        if (dive)
            Dive(t);

    }

    void Dive(float t) {

        diver.AddTorque(transform.forward * -diveSpeed * t, ForceMode.VelocityChange);

        float bodyWidth;
        bodyWidth = shoulderWidth + ((wingspan - shoulderWidth) * ((diver.transform.eulerAngles.z / Mathf.PI) % 1));

        Vector3 currScale = new Vector3(height, headSize, bodyWidth);
        diver.transform.localScale = currScale;
        boxCollide.transform.localScale = currScale;

    }

}
