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
		
		GameObject bullet = Instantiate(BulletPrefab) as GameObject;
		bullet.rigidbody.AddForce(transform.forward * BulletSpeed);
	}
}
