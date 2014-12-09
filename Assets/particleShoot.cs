using UnityEngine;
using System.Collections;

public class particleShoot : MonoBehaviour {

	public GameObject particle;
	Transform firePoint;
	
	
	void Awake() {
		firePoint=transform.FindChild("FirePoint");
	//	if (firePoint==null && DebugShot==true){
	//		Debug.LogError ("No Fire Point!!!");
	//	}
		
	}
	
	// Update is called once per frame
	void Update () {
	//	if (Input.GetMouseButton(0)){
		//	Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
       //     if (Physics.Raycast(ray)){
            //    Instantiate(particle, firePoint, Quaternion.identity);
			//}
		//}
	}
}
