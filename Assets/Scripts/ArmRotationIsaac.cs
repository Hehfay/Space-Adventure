using UnityEngine;
using System.Collections;
using MovementIsaac;

public class ArmRotationIsaac : MonoBehaviour {
		

	public int rotationOffset = 0;
	bool facingRight = true;
	public GameObject player;

	// Update is called once per frame
	void Update () {
				// subtracting the position of the player from the mouse position
				Vector3 difference = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position;
				difference.Normalize ();		// normalizing the vector. Meaning that all the sum of the vector will be equal to 1

				float rotZ = Mathf.Atan2 (difference.y, difference.x) * Mathf.Rad2Deg;	// find the angle in degrees
				float rotate = rotZ + rotationOffset;
				if (rotate > 90)
						MovementIsaac.MovementIsaac.Flip();
				else if (rotate < -90) {
						rotate = -90;
						transform.rotation = Quaternion.Euler (0f, 0f, rotate);
				} else
						transform.rotation = Quaternion.Euler (0f, 0f, rotate);


				if (!facingRight) {


				}
		}

}
