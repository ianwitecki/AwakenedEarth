﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProverbTransition : MonoBehaviour {

	// Use this for initialization
	void Start()
	{
		StartCoroutine(Example());
	}

	IEnumerator Example()
	{
		yield return new WaitForSeconds(5);
		SceneManager.LoadScene("CaveGeneratorScene");
	}

}
