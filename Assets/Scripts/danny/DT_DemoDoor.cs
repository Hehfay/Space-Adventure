﻿using UnityEngine;
using System.Collections;

public class DT_DemoDoor : MonoBehaviour {
	public string scene;
	// Use this for initialization
	void Start () {
		Debug.Log("Walk through door to get to a new scene.");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D( Collider2D player)
	{
		Debug.Log("2D Trigger");
		Application.LoadLevel(scene);
	}

}
