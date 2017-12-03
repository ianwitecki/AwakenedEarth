using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerCollide : MonoBehaviour {


	private Text elevationText;

	void Start() {

		elevationText = GameObject.Find ("EleText").GetComponent<Text> ();

	}

	void OnCollisionEnter(Collision collision)
	{
		if(transform.position.y < 20)
			SceneManager.LoadScene ("GameWin");
		SceneManager.LoadScene ("GameOver");
	}


	void Update() {

		int elevation = (int)(transform.position.y - 10000f);
		if (elevation % 5 == 0)
		elevationText.text = "Elevation: "+elevation;
			
	}
	
}
