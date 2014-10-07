using UnityEngine;
using System.Collections;

public class IM_ArmRotation : MonoBehaviour {
		
	public IM_Movement player;

	void Start() {
		}
	

	// Update is called once per frame
	void FixedUpdate () {
				
		// subtracting the position of the player from the mouse position		
		Vector3 difference = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position;

		difference.Normalize ();		// normalizing the vector. Meaning that all the sum of the vector will be equal to 1

		if (player.facingRight == false) {
			difference.y *= -1;
		}

		float theAngle = Mathf.Atan2 (difference.y, difference.x) * Mathf.Rad2Deg;	// find the angle in degrees

		if((theAngle > 90 || theAngle < -90) && (player.facingRight)){
			player.flipLeft();
		}
		if ((theAngle < 90 && theAngle > -90) && (!(player.facingRight))){
			player.flipRight();
		}
		/*if (theAngle == 90) {
						theAngle = 90;
				}
		if (theAngle == -90) {
						theAngle = -90;
				}*/

		if (player.facingRight == false) {
						theAngle -= 180;
				}
	

		transform.rotation = Quaternion.Euler (0f, 0f, theAngle);
		
	}
}








