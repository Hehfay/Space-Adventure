using UnityEngine;
using System.Collections;

public class BulletCreation : MonoBehaviour {
	
	public GameObject BulletPrefab;
	public float BulletSpeed;
	
	void Update () {
		
		if (Input.GetMouseButtonDown(0)){
			
			Shoot();
		}
	}
	
	void Shoot() {
		
	//	GameObject bullet = Instantiate(BulletPrefab) as GameObject;
		//Instantiate(BulletPrefab) as GameObject;
		
		//bullet.rigidbody.AddForce(transform.forward * BulletSpeed);

		Vector3 difference = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position;
		difference.Normalize ();		// normalizing the vector. Meaning that all the sum of the vector will be equal to 1
		
		float rotZ = Mathf.Atan2 (difference.y, difference.x) * Mathf.Rad2Deg;	// find the angle in degrees
		transform.rotation = Quaternion.Euler (0f, 0f, rotZ );
	}
}
