using UnityEngine;
using System.Collections;

public class GAMESETTINGS : MonoBehaviour {
	
	public static string PreviousDoor;
	public static string CurrentScene;
	// Use this for initialization
	
	
	void Start () {
	  PreviousDoor = "none";
	  CurrentScene ="00_00StartScene";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void Awake (){
	
		DontDestroyOnLoad(this);
			  PreviousDoor = "none";
			  CurrentScene ="00_00StartScene";

	}
}
