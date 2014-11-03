using UnityEngine;
using System.Collections;

public class TelekineticShot : MonoBehaviour {

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
		if(WeaponSelect.currentWeapon == 2){
			renderer.enabled = true; //
			
			// Weapon attributes are only executed when the weapons render is on.
			// Shoot MOve
			if(fireRate==0){
				if (Input.GetMouseButtonDown(0)){
					
					ShootMove();
				}
			}
			else{
				if (Input.GetMouseButton(0)&& Time.time> timeToFire){
					
					timeToFire=Time.time+1/fireRate;
					ShootMove();
				}
			}
		}
		else{
			renderer.enabled = false; //
		}
	
	}
	
	
	// Move Function
	
	void ShootMove(){
		Debug.Log("test:Move");
		Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
		Vector2 firePointPosition = new Vector2(firePoint.position.x,firePoint.position.y);
		Vector2 p;
		Vector2 s;
		RaycastHit2D hit = Physics2D.Raycast(firePointPosition,mousePosition-firePointPosition, 100, whatToHit);
		Debug.DrawLine(firePointPosition, (mousePosition-firePointPosition) *100);
		if (hit.collider != null){
			Debug.DrawLine(firePointPosition,hit.point,Color.blue);
			Debug.Log("Hit:"+hit.collider.name);
			p = hit.collider.gameObject.transform.localPosition;
			s =hit.collider.gameObject.transform.localScale;

			if (p.x - mousePosition.x <= 0.5 *s.x && p.x - mousePosition.x >=-0.5 * s.x ){
				if (p.y - mousePosition.y <= 0.5 *s.y && p.y - mousePosition.y >=-0.5 * s.y ){
					hit.collider.gameObject.transform.localPosition = mousePosition;
			
				}
			}
		}
	}
}
