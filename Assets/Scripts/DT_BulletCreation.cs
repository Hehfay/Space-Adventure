using UnityEngine;
using System.Collections;

public class DT_BulletCreation : MonoBehaviour {
	
	public GameObject BulletPrefab;

	void Update () {
		
		if( Input.GetMouseButtonDown(0))
		{
			Debug.Log ("Mouse Click");
			
			Shoot();
		}
	}
	
	void Shoot() {
		
		GameObject bullet = Instantiate(BulletPrefab) as GameObject;

		bullet.transform.position = transform.position;

		Vector3 clickPoint = Camera.main.ScreenToWorldPoint( Input.mousePosition);
		clickPoint.z = 0;
		Vector3 difference = clickPoint - transform.position;

		Debug.Log( difference);
		Debug.Log( difference.magnitude);

		difference.Normalize (); // Normalizing the direction vector. (Meaning make its length equal to 1.)

		Debug.Log( difference);
		Debug.Log( difference.magnitude);

		DT_BulletMovement bulletScript = bullet.GetComponent<DT_BulletMovement>();
		bulletScript.direction = difference;
		
		float rotZ = Mathf.Atan2 (difference.y, difference.x) * Mathf.Rad2Deg;	// find the angle in degrees
		transform.rotation = Quaternion.Euler (0f, 0f, rotZ );
	}
}
