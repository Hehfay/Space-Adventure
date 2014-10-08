using UnityEngine;
using System.Collections;

public class ShotScript : MonoBehaviour {
	
	public float fireRate=0;
	public LayerMask whatToHit;
	float timeToFire=0;
	Transform firePoint;
	
	
	void Awake() {
		firePoint=transform.FindChild("FirePoint");
		if (firePoint==null){
			Debug.LogError ("No Fire Point!!!");
		}
		
	}
	
	void Update(){
		
		if(fireRate==0){
			if (Input.GetMouseButtonDown(0)){
				
				Shoot();
			}
		}
		else{
			if (Input.GetMouseButton(0)&& Time.time> timeToFire){
				
				timeToFire=Time.time+1/fireRate;
				Shoot();

				
			}
		}
	}
	void Shoot(){
		Debug.Log("test");
		Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
		Vector2 firePointPosition = new Vector2(firePoint.position.x,firePoint.position.y);
		RaycastHit2D hit = Physics2D.Raycast(firePointPosition,mousePosition-firePointPosition, 100, whatToHit);
		Debug.DrawLine(firePointPosition, (mousePosition-firePointPosition) *100);
		if (hit.collider != null){
			Debug.DrawLine(firePointPosition,hit.point,Color.red);
			Debug.Log("Hit:"+hit.collider.name);

		}
	}
	
}
