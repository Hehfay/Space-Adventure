/// IM_ArmRotation.cs Script
/// This script rotates the arm of the player to point
/// wherever the mouse is. When the mouse goes on the
/// other side of where the player is facing, the player
/// is flipped. The scale and a position shift variable
/// are included to make the flipping look smoother.ß
///
/// -Written by Isaac Meisner

using UnityEngine;
using System.Collections;

public class IM_ArmRotation : MonoBehaviour {

	public IM_PlayerMovement player;

	void FixedUpdate () {
				
		// subtracting the position of the player from the mouse position		
		Vector3 difference = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position;

		difference.Normalize ();

		if (player.facingRight == false) {
			difference.y *= -1;
		}

		float theAngle = Mathf.Atan2 (difference.y, difference.x) * Mathf.Rad2Deg;	// find the angle in degrees



		if (theAngle == 90f) {

		} else if (theAngle == -90f) {

		} else if ((theAngle < 90f && theAngle > -90f) && (!(player.facingRight))){
			player.flipRight();
		} else if ((theAngle > 90f || theAngle < -90f) && (player.facingRight)) {
			player.flipLeft ();
		}

		if (player.facingRight == false) {
						theAngle -= 180f;
		}
	
		print (theAngle);

		transform.rotation = Quaternion.Euler (0f, 0f, theAngle);
		
	}

}








