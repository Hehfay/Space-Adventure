using UnityEngine;
using System.Collections;

public class GAMESETTINGS : MonoBehaviour {
	
	public static string PreviousDoor;
	public static string CurrentScene;
	public static string PREVIOUS_SCENE;
	public static int PLAYERHEALTH;
	public static int CURRENTWEAPON;
	public static string ACTIVEGUNTEXT;
	// Use this for initializWation
	
	
	void Start () {
	  PreviousDoor = "none";
	  CurrentScene ="00_00StartScene";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void Awake (){
	
		DontDestroyOnLoad(this);
		PLAYERHEALTH = 10;
		CURRENTWEAPON=1;
		ACTIVEGUNTEXT="Grow and Shrink";
			  

	}
}
