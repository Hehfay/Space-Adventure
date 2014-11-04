using UnityEngine;
using System.Collections;

public class WeaponSelect : MonoBehaviour {

	public static int currentWeapon =1;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Alpha1)){ //if I press the "1" button, switch currentWeapon to 1.
			currentWeapon = 1;
		}
		else if(Input.GetKeyDown(KeyCode.Alpha2)){ //if I press the "1" button, switch currentWeapon to 2.
			currentWeapon = 2;
		}
	
	}
}
