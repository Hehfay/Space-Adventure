using UnityEngine;
using System.Collections;

public class Enemy_AI : MonoBehaviour 
{
	/*************/
	/* VARIABLES */
	/*************/

	// Enemy Speeds
	static private float standingSpeed   = 0.0f;
	static private float patrollingSpeed = 0.025f;
	static private float attackingSpeed  = 0.075f;
	float[] speed = {standingSpeed, patrollingSpeed, attackingSpeed};

	// Enemy's current direction flag 
	private enum directions{
		left,
		right
	}; 
	private directions currentDirection;
	
	// Indicating what state the enemy is in 
	private enum alertStatus{
		standing,
		patrolling,
		attacking
	}; 
	private alertStatus enemyAlertStatus;
	
	// Used for ray cast hit detection 
	RaycastHit2D hit;

	/*************/
	/* Functions */
	/*************/

	// Use this for initialization 
	void Start(){
		currentDirection = directions.left;
		enemyAlertStatus = alertStatus.attacking;
	}

	// Called on fixed intervals
	void FixedUpdate(){	
		switch ( currentDirection ){

			case directions.left:
				transform.Translate(Vector3.left * speed[(int)enemyAlertStatus]);
				hit = Physics2D.Raycast (transform.position, transform.TransformDirection(Vector3.left), 10);
				rayCollision(hit);	
				break;

			case directions.right:
				transform.Translate(Vector3.right * speed[(int)enemyAlertStatus]);
				hit = Physics2D.Raycast (transform.position, transform.TransformDirection(Vector3.right), 10);
				rayCollision(hit);	
				break;
		}
	}
	
	// Collisions between the enemy and other tags
	void OnTriggerEnter2D(Collider2D other){	
		if(other.gameObject.tag == "Left"){
			currentDirection = directions.right;
		}	
		if(other.gameObject.tag == "Right"){
			currentDirection = directions.left;
		}
	}

	// Collisions between enemy's raycast and other tags
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
