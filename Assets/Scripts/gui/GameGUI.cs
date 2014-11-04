using UnityEngine;
using System.Collections;

public class GameGUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI() {
		 GUI.Box(new Rect(1, 1, Screen.width *0.1f, Screen.height *0.1f), "Active Gun");
	}
}
