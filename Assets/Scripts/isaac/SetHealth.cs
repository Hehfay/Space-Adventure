using UnityEngine;
using System.Collections;

public class SetHealth : MonoBehaviour {

	public GUIText HealthText;

	// Use this for initialization
	void Start () {
		/*if(GAMESETTINGS.CurrentScene == "startScene")
			HealthText.enabled = false;*/
	}
	
	// Update is called once per frame
	void Update () {
		if(GAMESETTINGS.CurrentScene != "startScene")
			SetHealthText ();
	}

	public void SetHealthText(){
		HealthText.text = "Health: " + GAMESETTINGS.PLAYERHEALTH.ToString ();
	}
			
	/*
	void SetPickupText(){
			pickupText.text = "Pickups: " + pickupCount.ToString ();
		}*/

}
