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
	float positionShift = 0.2830832f;
	float scaleOfPlayer = 3.549589f;
	Vector3 mousePos;
	float theta;

	void FixedUpdate () {

		mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position;
		mousePos.Normalize ();		// normalizing the vector. Meaning that all the sum of the vector will be equal to 1

		float x = mousePos.x;
		float y = mousePos.y;

		if (player.facingRight == false) {
			y *= -1;
		}

		float theta = Mathf.Atan2 (y, x) * Mathf.Rad2Deg;	// find the angle in degrees
		
		//Flip left
		if ((theta > 90 || theta < -90) && (player.facingRight)) {
			player.facingRight = false;
			player.transform.localScale = new Vector3( -3.549589f, 3.549589f, 1);
			transform.localScale = new Vector3(  -0.8f, -0.8f, 1);
			Vector3 pos = player.transform.position;
			pos.x -=  positionShift;
			player.transform.position = pos;
		}
		//Flip right
		if ((theta < 90 && theta > -90) && (player.facingRight == false)) {
			player.facingRight = true;
			player.transform.localScale = new Vector3(  3.549589f, 3.549589f, 1);
			transform.localScale = new Vector3(  0.8f, 0.8f, 1);
			Vector3 pos = player.transform.position;
			pos.x +=  positionShift;
			player.transform.position = pos;
		}
	
		transform.localRotation = Quaternion.Euler (0f, 0f, theta);

		/*Vector2 mouse = Camera.main.ScreenToViewportPoint (Input.mousePosition);
		Vector3 objpos = Camera.main.WorldToViewportPoint (transform.position);
		Vector2 relobjpos = new Vector2 (objpos.x - 0.5f, objpos.y - 0.5f);
		Vector2 relmousepos = new Vector2 (mouse.x - 0.5f, mouse.y - 0.5f) - relobjpos;
		float angle = Vector2.Angle (Vector2.up, relmousepos);
		if (relmousepos.x > 0)
						angle = 360 - angle;
		Quaternion quat = Quaternion.identity;
		angle += 90;
		quat.eulerAngles = new Vector3 (0, 0, (angle));
		transform.rotation = quat;

		if((angle > 90.0f && angle < 270.0f) && (player.facingRight == true)){
			Vector3 pos = player.transform.position;
			pos.x -= positionShift;
			player.transform.position = pos;
			player.facingRight = false;
			float yrot = 180.0f;
			Quaternion roatio = player.transform.localRotation;
			roatio.y = yrot;
			player.transform.localRotation = roatio;
		}

		if((angle > 270.0f && angle < 450.0f) && (player.facingRight == false)){
			Vector3 pos = player.transform.position;
			pos.x += positionShift;
			player.transform.position = pos;
			player.facingRight = true;
			float yrot = 0.0f;
			Quaternion roatio = player.transform.localRotation;
			roatio.y = yrot;
			player.transform.localRotation = roatio;
		}*/

	}
}









