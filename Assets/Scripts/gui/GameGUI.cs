using UnityEngine;
using System.Collections;

//Attach to a preferably empty game object like "GameManager"
public class GameGUI : MonoBehaviour {

	public int sec;
	public int min;

	// Use this for initialization
	void Awake () {
		sec = 60;
		min = 2;
		InvokeRepeating ("Stopwatch", 1, 1);
	}



	// Update is called once per frame
	void Update () {

	}
	void OnGUI() {
		GUI.Box(new Rect(1, 1, Screen.width *0.1f, Screen.height *0.1f), "Active Gun");

		GUI.Box (new Rect (Screen.width - Screen.width*0.25f, 5, 
		                   Screen.width * 0.15f, Screen.height * 0.05f),
		         		   "Time: " + "(" + min +"minutes"+ ":" + sec +"seconds"+ ")");
	}

	//--------------------------------------------------------
	// Stopwatch()
	//
	// Counts down from a set time to 0 minutes and 
	// 0 seconds and currently ends in an inflammatory 
	// debug message depending on the scene the 
	// player has reached.
	//--------------------------------------------------------
	void Stopwatch(){
		sec--;
		if(sec < 0){
			min--;
			sec = 60;
		}
		
		if(min<1 && sec<1){
			CancelInvoke("Stopwatch");
			if(GAMESETTINGS.CurrentScene == "00_00StartScene"){
				Debug.Log ("Were you taking a nap?");
			}
			else if(GAMESETTINGS.CurrentScene != "00_00StartScene"){
				Debug.Log ("Too Slow!");
			}
		}
	}

}

