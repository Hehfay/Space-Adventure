using UnityEngine;
using System.Collections;

public class WeaponSelect : MonoBehaviour {

	public static int currentWeapon;
	public GUIText ActiveGunText;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(GAMESETTINGS.CurrentScene != "startScene"){
			ActiveGunText.enabled = true;
			ActiveGunText.text = GAMESETTINGS.ACTIVEGUNTEXT;
			if(Input.GetKeyDown(KeyCode.Alpha1)){ //if I press the "1" button, switch currentWeapon to 1.
				currentWeapon = 1;
				ActiveGunText.text = "Grow and Shrink";
				GAMESETTINGS.ACTIVEGUNTEXT="Grow and Shrink";
			}
			else if(Input.GetKeyDown(KeyCode.Alpha2)){ //if I press the "1" button, switch currentWeapon to 2.
				currentWeapon = 2;
				ActiveGunText.text = "Telekinesis";
				GAMESETTINGS.ACTIVEGUNTEXT="Telekinesis";
			}
		}
		else{
			ActiveGunText.enabled = false;
		}
	}

	void Awake(){
		GAMESETTINGS.CURRENTWEAPON = currentWeapon;
		ActiveGunText.text = GAMESETTINGS.ACTIVEGUNTEXT;
		currentWeapon = 1;
	}
}
