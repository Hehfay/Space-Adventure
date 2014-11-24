using UnityEngine;
using System.Collections;

public class GAMESETTINGS : MonoBehaviour {
	
	public static int PreviousDoor;
	public static string CurrentScene;
	public static int PLAYERHEALTH;
	public static int CURRENTWEAPON;
	public static string ACTIVEGUNTEXT;
	// Use this for initializWation
	
	
	void Start () {
	  PreviousDoor = 0;
	  CurrentScene ="00_00StartScene";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void Awake (){
	
		DontDestroyOnLoad(this);
			//  PreviousDoor = 0;
			//  CurrentScene ="00_00StartScene";
			  PLAYERHEALTH = 10;
			  CURRENTWEAPON=1;
			  ACTIVEGUNTEXT="Grow and Shrink";
			  

	}
}
