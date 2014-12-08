using UnityEngine;
using System.Collections;

public class UIManagerScript : MonoBehaviour {

	public GUIText pauseText;

	void Start(){
		pauseText.enabled = false;
		GAMESETTINGS.PAUSED = false;
	}

	void Update()
	{
		if (Input.GetKeyUp ("p") && !GAMESETTINGS.PAUSED) {
			PauseGame();
		}else if (Input.GetKeyUp ("p") && GAMESETTINGS.PAUSED){
			UnpauseGame();
		}
	}

	public void StartGame()
	{
		GAMESETTINGS.PREVIOUS_SCENE = "startScene";
		Application.LoadLevel("00_00StartScene");
	}

	public void PauseGame()
	{
		GAMESETTINGS.PAUSED = true;
		Time.timeScale = 0;
		pauseText.enabled = true;
	}

	public void UnpauseGame()
	{
		GAMESETTINGS.PAUSED = false;
		Time.timeScale = 1; 
		pauseText.enabled = false;
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
