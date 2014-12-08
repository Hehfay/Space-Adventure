using UnityEngine;
using System.Collections;

public class UIManagerScript : MonoBehaviour {
	
	public bool paused;
	public GUIText pauseGUI;

	void Start(){
		pauseGUI.enabled = false;
		paused = false;
	}

	void Update()
	{
		if (Input.GetKey ("p") && paused == false) {
			Time.timeScale = 0;
			pauseGUI.enabled = true;
			paused = true;
		}else if (Input.GetKey ("p") && paused){
			Time.timeScale = 1;
			pauseGUI.enabled = false;
			paused = false;
		}
	}

	public void StartGame()
	{
		Application.LoadLevel("00_00StartScene");
	}

	public void Settings()
	{
		Application.LoadLevel ("Settings");
	}

	public void QuitGame()
	{
		Application.LoadLevel ("startScreen");
	}
}
