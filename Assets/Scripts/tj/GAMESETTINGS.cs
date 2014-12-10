using UnityEngine;
using System.Collections;

public class GAMESETTINGS : MonoBehaviour {
	
	public static string PreviousDoor;
	public static string CurrentScene;
	public static string PREVIOUS_SCENE;
	public static int PLAYERHEALTH;
	public static int CURRENTWEAPON;
	public static string ACTIVEGUNTEXT;
	public static bool PAUSED;
	public GUIText pauseText;
	public static bool DEAD;
	
	// Use this for initializWation

	void Start () {
	//  PreviousDoor = "none";
	  CurrentScene = "startScene";
	  PAUSED = false;
	  pauseText.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(CurrentScene != "startScene"){
			if (Input.GetKeyUp ("p") && !PAUSED) {
				PauseGame();
			}else if (Input.GetKeyUp ("p") && PAUSED){
				UnpauseGame();
			}
		}
		
		if(DEAD == true){
			ohManYouDied();
		}
	}

	public void PauseGame()
	{
		PAUSED = true;
		Time.timeScale = 0;
		pauseText.enabled = true;
	}
	
	public void UnpauseGame()
	{
		PAUSED = false;
		Time.timeScale = 1; 
		pauseText.enabled = false;
	}
	
	void Awake (){
		DontDestroyOnLoad(this);
		
		
		DEAD = false;
		PreviousDoor = "none";
		CurrentScene = "startScene";
		PAUSED = false;
		pauseText.enabled = false;
		PLAYERHEALTH = 10;
		CURRENTWEAPON=1;
		ACTIVEGUNTEXT="Grow and Shrink";

	}
	
	void ohManYouDied(){
		DEAD = false;
		Debug.Log("DEAD");
		Application.LoadLevel(CurrentScene);
	}


}
