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


	void OnTriggerEnter2D(Collider2D other){
				if (other.CompareTag ("Bullet")) {
						GAMESETTINGS.PLAYERHEALTH --;
						SetHealthText ();
						//other.gameObject.SetActive( false );
						Destroy (other.gameObject);
			if (GAMESETTINGS.PLAYERHEALTH <= 0) {
								Destroy (gameObject);
						}
				}
				/*if (other.CompareTag ("Pickup")) {
						other.gameObject.SetActive (false);
						pickupCount++;
				}*/
		}

	void SetHealthText(){
		HealthText.text = "Health: " + GAMESETTINGS.PLAYERHEALTH.ToString ();
	}
			
	/*
	void SetPickupText(){
			pickupText.text = "Pickups: " + pickupCount.ToString ();
		}*/

}
