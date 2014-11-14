using UnityEngine;
using System.Collections;

public class ShotScript : MonoBehaviour {
	
	public float fireRate=0;
	public LayerMask whatToHit;
	float timeToFire=0;
	public bool DebugShot; //Debug On/Off
	Transform firePoint;
	
	
	void Awake() {
		firePoint=transform.FindChild("FirePoint");
		if (firePoint==null && DebugShot==true){
			Debug.LogError ("No Fire Point!!!");
		}
		
	}
	
	void Update(){

		if(WeaponSelect.currentWeapon == 1){
			renderer.enabled = true; //enable the renderer of the weapon, so you can see it.
			
			//Do anything you have to do to make your weapon move, fire.. etc.

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
		else{
			renderer.enabled = false; //disable the renderer of the weapon, so you can't see it if you have another weapon.
		}
	}


	// Grow Function

	void ShootGrow(){
		if(DebugShot==true){
			Debug.Log("test");
		}
		Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
		Vector2 firePointPosition = new Vector2(firePoint.position.x,firePoint.position.y);
		RaycastHit2D hit = Physics2D.Raycast(firePointPosition,mousePosition-firePointPosition, 100, whatToHit);
		if(DebugShot==true){
			Debug.DrawLine(firePointPosition, (mousePosition-firePointPosition) *100);
		}
		if (hit.collider != null){
			if (hit.collider.gameObject.layer == 10){
				if(DebugShot == true){
					Debug.DrawLine(firePointPosition,hit.point,Color.red);
					Debug.Log("Hit:"+hit.collider.name);
					}
			}
			else{
				if(DebugShot==true){
					Debug.DrawLine(firePointPosition,hit.point,Color.red);
					Debug.Log("Hit:"+hit.collider.name);
				}
				//Upscale
				MaxAndMinSize max = hit.collider.GetComponent<MaxAndMinSize>();
				Vector3 s = hit.collider.gameObject.transform.localScale;
				if(max.Max.x > s.x && max.Max.y > s.y){
					s.x += .1f;
					s.y += .1f;
					hit.collider.gameObject.transform.localScale = s;
					//Increases Object Mass
					hit.collider.GetComponent<Rigidbody2D>().mass += .1f;
				}
			}
		}
	}

	// Shrink Function

	void ShootShrink(){
		if(DebugShot==true){
			Debug.Log("test");
		}
		Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
		Vector2 firePointPosition = new Vector2(firePoint.position.x,firePoint.position.y);
		RaycastHit2D hit = Physics2D.Raycast(firePointPosition,mousePosition-firePointPosition, 100, whatToHit);
		if(DebugShot==true){
			Debug.DrawLine(firePointPosition, (mousePosition-firePointPosition) *100);
		}
		if (hit.collider != null){
			if (hit.collider.gameObject.layer == 10){
				if(DebugShot==true){
					Debug.DrawLine(firePointPosition,hit.point,Color.green);
					Debug.Log("Hit:"+hit.collider.name);
					}
			}
			else{
				if(DebugShot==true){
					Debug.DrawLine(firePointPosition,hit.point,Color.green);
					Debug.Log("Hit:"+hit.collider.name);
				}
				//DownScales
				MaxAndMinSize min = hit.collider.GetComponent<MaxAndMinSize>();
				Vector3 s = hit.collider.gameObject.transform.localScale;
				if(min.Min.x < s.x && min.Min.y < s.y){
					s.x -= .1f;
					s.y -= .1f;
					hit.collider.gameObject.transform.localScale = s;
					//Decreases Object Mass
					hit.collider.GetComponent<Rigidbody2D>().mass -= .1f;
				}
			}
		}
	}
}
