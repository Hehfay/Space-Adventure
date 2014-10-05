using UnityEngine;
using System.Collections;

public class Enemy_AI : MonoBehaviour 
{
	/* Enemy's current facing direction flag */
	private enum directions{
		left,
		right
	};
	private directions currentDirection;
	
	/* Indicating what state the enemy is in */
	private enum alertStatus{
		standing,
		patroling,
		attacking
	}; 
	private alertStatus enemyAlertStatus;
	
	/* Used for ray cast hit detection */	
	RaycastHit2D hit;
		
	/* Use this for initialization */
	void Start(){
		currentDirection = directions.right;
	}

	void FixedUpdate(){	
		switch ( currentDirection ){

			case directions.left:
				transform.Translate(Vector3.left * 0.05f);
				hit = Physics2D.Raycast (transform.position, transform.TransformDirection(Vector3.left), 10);
				rayCollision(hit);	
				break;

			case directions.right:
				transform.Translate(Vector3.right * 0.05f);
				hit = Physics2D.Raycast (transform.position, transform.TransformDirection(Vector3.right), 10);
				rayCollision(hit);	
				break;
		}
	}

	void OnTriggerEnter2D(Collider2D other){	
		if(other.gameObject.tag == "Left"){
			currentDirection = directions.right;
		}	
		if(other.gameObject.tag == "Right"){
			currentDirection = directions.left;
		}
	}
	
	void rayCollision(RaycastHit2D hit){
		if(hit.collider != null){
			if(hit.collider.tag == "Cover"){
				Debug.Log("Cover was hit.");
			}
		}
		else{
			Debug.Log ("Nothing was hit.");
		} 
	}
}
