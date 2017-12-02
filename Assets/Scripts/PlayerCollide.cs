using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollide : MonoBehaviour {

	void OnCollisionEnter(Collision collision)
	{
		if(transform.position.y < 20)
			SceneManager.LoadScene ("GameWin");
		SceneManager.LoadScene ("GameOver");
	}
}
