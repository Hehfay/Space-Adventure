using UnityEngine;
using System.Collections;

public class WeaponSelect : MonoBehaviour {

	public static int currentWeapon =1;
	public GUIText ActiveGunText;

	// Use this for initialization
	void Start () {
		ActiveGunText.text = "Grow and Shrink";

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Alpha1)){ //if I press the "1" button, switch currentWeapon to 1.
			currentWeapon = 1;
			ActiveGunText.text = "Grow and Shrink";
		}
		else if(Input.GetKeyDown(KeyCode.Alpha2)){ //if I press the "1" button, switch currentWeapon to 2.
			currentWeapon = 2;
			ActiveGunText.text = "Telekinesis";
		}
	
	}
}
