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
		// Shoot Grow
		if(fireRate==0){
			if (Input.GetMouseButtonDown(0)){
				
				ShootGrow();
			}
		}
		else{
			if (Input.GetMouseButton(0)&& Time.time> timeToFire){
				
				timeToFire=Time.time+1/fireRate;
				ShootGrow();

				
			}
		}
		//Shoot Shrink

		if(fireRate==0){
			if (Input.GetMouseButtonDown(1)){
				
				ShootShrink();
			}
		}
		else{
			if (Input.GetMouseButton(1)&& Time.time> timeToFire){
				
				timeToFire=Time.time+1/fireRate;
				ShootShrink();
				
				
			}
		}
	}


	// Grow Function

	void ShootGrow(){
		Debug.Log("test");
		Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
		Vector2 firePointPosition = new Vector2(firePoint.position.x,firePoint.position.y);
		RaycastHit2D hit = Physics2D.Raycast(firePointPosition,mousePosition-firePointPosition, 100, whatToHit);
		Debug.DrawLine(firePointPosition, (mousePosition-firePointPosition) *100);
		if (hit.collider != null){
			Debug.DrawLine(firePointPosition,hit.point,Color.red);
			Debug.Log("Hit:"+hit.collider.name);
			//collider.gameObject.transform.localScale = new Vector3(transform.localScale.x * 1.5f, transform.localScale.y * 1.5f,0f);
			Vector3 s = hit.collider.gameObject.transform.localScale;
			s.x += .1f;
			s.y += .1f;
			hit.collider.gameObject.transform.localScale = s;
			//collider.gameObject.transform.localScale.y += 0.5f;
		}
	}

	// Shrink Function

	void ShootShrink(){
		Debug.Log("test");
		Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
		Vector2 firePointPosition = new Vector2(firePoint.position.x,firePoint.position.y);
		RaycastHit2D hit = Physics2D.Raycast(firePointPosition,mousePosition-firePointPosition, 100, whatToHit);
		Debug.DrawLine(firePointPosition, (mousePosition-firePointPosition) *100);
		if (hit.collider != null){
			Debug.DrawLine(firePointPosition,hit.point,Color.green);
			Debug.Log("Hit:"+hit.collider.name);
			//collider.gameObject.transform.localScale = new Vector3(transform.localScale.x * 1.5f, transform.localScale.y * 1.5f,0f);
			if ( hit.collider.gameObject.transform.localScale.x > .2 && hit.collider.gameObject.transform.localScale.y > .2){
				Vector3 s = hit.collider.gameObject.transform.localScale;
				s.x -= .1f;
				s.y -= .1f;
				hit.collider.gameObject.transform.localScale = s;
				//collider.gameObject.transform.localScale.y += 0.5f;
			}
		}
	}
	
}
