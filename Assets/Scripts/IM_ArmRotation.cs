using UnityEngine;
using System.Collections;

public class IM_ArmRotation : MonoBehaviour {
		
	public IM_Movement player;

	void Start() {
		}

	public int rotationOffset = 0;
	//bool facingRight = true;

	// Update is called once per frame
	void FixedUpdate () {
				
		// subtracting the position of the player from the mouse position		
		Vector3 difference = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position;
		difference.Normalize ();		// normalizing the vector. Meaning that all the sum of the vector will be equal to 1
		float rotZ = Mathf.Atan2 (difference.y, difference.x) * Mathf.Rad2Deg;	// find the angle in degrees
		float rotate = rotZ + rotationOffset;

				if ((rotate > 90 || rotate < -90) && (player.facingRight = true)) {
						player.FlipLeft ();
						rotate *= 1;
				} else if ((rotate < 90 || rotate > -90) && (player.facingRight = false)) {
						player.FlipRight ();
						rotate *= 1;
				} else if (rotate < -90 && (player.facingRight = true)) {
						rotate = -90;
				} else if (rotate > -90 && (player.facingRight = false)) {
						rotate = -90;
				}

		transform.rotation = Quaternion.Euler (0f, 0f, rotate);

		}
}
