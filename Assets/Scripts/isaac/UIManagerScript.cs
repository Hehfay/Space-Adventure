using UnityEngine;
using System.Collections;

public class UIManagerScript : MonoBehaviour {
	
	public void StartGame()
	{
		GAMESETTINGS.PREVIOUS_SCENE = "startScene";
		GAMESETTINGS.CurrentScene = "00_00StartScene";
		Application.LoadLevel("00_00StartScene");
	}

	public void Settings()
	{
		Application.LoadLevel ("Settings");
	}

	public void backFromSettings(){
		Application.LoadLevel ("startScene");
	}

	public void QuitGame()
	{
		Application.LoadLevel ("startScene");
	}

	void Awake(){
		//GAMESETTINGS.PREVIOUS_SCENE = "startScene";
		//GAMESETTINGS.CurrentScene = "00_00StartScene";
	}
}
