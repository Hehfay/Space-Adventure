using UnityEngine;
using System.Collections;

public class BombExplosion : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if (Time.timeSinceLevelLoad >= 60) {
			Application.LoadLevel("00_00StartScene");
				}
	}
}
