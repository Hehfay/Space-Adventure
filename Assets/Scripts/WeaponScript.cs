using UnityEngine;
using System.Collections;

public class RaycastShooting : MonoBehaviour {
	
	
	Transform Effect;
	float TheDammage = 100;
	object particleClone;
	RaycastHit hit;
	
	void Update (){
		
		
		Vector3 fwd = transform.TransformDirection(Vector3.forward); //the direction the player is facing
		
		if (Input.GetMouseButtonDown(0)) //if the left mouse button is pressed do ....
		{
			
			if (Physics.Raycast(transform.position, fwd, 10)) //if a game object is in front of player but within 10 units of it trigger a hit
			{
				
				//particleClone = Instantiate(Effect, hit.point, Quaternion.LookRotation(hit.normal));
				//Destroy(particleClone.gameObject, 2);
				hit.transform.SendMessage("ApplyDammage", TheDammage, SendMessageOptions.DontRequireReceiver); //Call the method Apply Damage in the gameobject that is hit
			}
		}
		
	}
