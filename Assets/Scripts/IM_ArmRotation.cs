/// IM_ArmRotation.cs Script
/// This script rotates the arm of the player to point
// wherever the mouse is. When the mouse goes on the
// other side of where the player is facing, the player
// is flipped. The scale and a position shift variable
// are included to make the flipping look smoother.ß
//
// -Written by Isaac Meisner

using UnityEngine;
using System.Collections;

public class IM_ArmRotation : MonoBehaviour {

	public IM_PlayerMovement player;
	private float theta0 = 90.0f;

	void FixedUpdate () {
				
		// subtracting the position of the player from the mouse position		
		Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);

		float x = mousePos.x;
		float y = mousePos.y /** -1.0f*/;
		
		float theta;
		float dtheta;

		theta = Mathf.Atan2 (x, y) * Mathf.Rad2Deg;	// find the angle pointing of vector pointing at mouse in degrees

		dtheta = theta0 - theta; //difference with current angle

		transform.RotateAround (new Vector3 (0, 0, 0), new Vector3 (0, 0, 1), dtheta); //Rotate to the new angle

		theta0 = theta; //save the new angle

		//Flip left
		if (x < 0.0f) {
			player.transform.localScale = new Vector3( -3.549589f, 3.549589f, 1);
			transform.localScale = new Vector3(  1, -1, 1);
			player.transform.position = new Vector3( -0.3830832f, 0, 0);
		}
		//Flip right
		if (x > 0.0f) {
			player.transform.localScale = new Vector3(  3.549589f, 3.549589f, 1);
			transform.localScale = new Vector3(  1, 1, 1);
			player.transform.position = new Vector3( 0.3830832f, 0, 0);
		}
		
	}

}








