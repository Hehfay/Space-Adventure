/*******************/
/* Enemy AI script */
/* Author: Hehfay  */
/*******************/

//TODO Add layermask argument to all Physics2D.Raycast function calls.

using UnityEngine;
using System.Collections;

public class JH_Enemy_AI : MonoBehaviour 
{
	/*************/
	/* VARIABLES */
	/*************/

	// ENEMY LINE OF SIGHT
	RaycastHit2D lineOfSight;	

	// ENEMY DIRECTION
	Vector3 currentDirectionVector;

	// WHAT THE ENEMY LINE OF SIGHT RAY WILL COLIDE WITH
	public LayerMask whatToHit;
	
	public enum directions{
		left,
		right
	}; 
	public directions currentDirection;
	
	public enum alertStatus{
		standing,	
		casualPatrol,
		patrolling,
		attacking
	}; 
	public alertStatus enemyAlertStatus;
	
	static float standingSpeed   = 0.0f;
	static float casualSpeed     = 0.015f;
	static float patrollingSpeed = 0.025f;
	static float attackingSpeed  = 0.075f;	
	float[] speed = {
		standingSpeed,
	 	casualSpeed,	
		patrollingSpeed, 
		attackingSpeed
	};	

	/*************/
	/* Functions */
	/*************/

	// Use this for initialization 
	void Start(){
		// Set the starting direction based on gui selection
		if( currentDirection == directions.left ){
				currentDirectionVector = new Vector3(-1,0,0); // Left
		}
		else {
			currentDirectionVector = new Vector3(1,0,0); // Right
		}
	}

	// Called on fixed intervals
	void FixedUpdate(){		
		lineOfSight = Physics2D.Raycast (transform.position, transform.TransformDirection(currentDirectionVector), 10, whatToHit);
		rayCollision(lineOfSight);		
		enemyMovement();
	}
	
	// Collisions between the enemy and other tags
	void OnTriggerEnter2D(Collider2D other){	
		if( other.gameObject.tag == "Edge Collider" || other.gameObject.tag == "Enemy" ){
			changeDirection();
		}	
	}

	// Collisions between enemy's line of sight raycast and other tags
	void rayCollision(RaycastHit2D lineOfSight){
		if( lineOfSight.collider != null )
		{
			if( lineOfSight.collider.tag == "Cover" ){
				Debug.Log("Cover was in line of sight");
			}
			if( lineOfSight.collider.tag == "Player" ){
				enemyAlertStatus = alertStatus.attacking;
				//If enemy sees the player go into attack mode
			}
		}
		else{
			Debug.Log ("Nothing was in line of sight.");
		} 
	}

	void changeDirection(){
		if( currentDirection == directions.left ){
			currentDirection = directions.right;
			currentDirectionVector = new Vector3(1,0,0); // Right
		}
		else{
			currentDirection = directions.left;
			currentDirectionVector = new Vector3(-1,0,0); // Left
		}
	}

	void enemyMovement(){	
		switch ( enemyAlertStatus )
		{	
			case alertStatus.standing:	
				// TODO Co-routine to handling changing directions
				float random_number = Random.value;	
				if( random_number >= .99 ){
					changeDirection();
				}	
			break;
				
			case alertStatus.attacking:
			// TODO
			case alertStatus.casualPatrol:
			// TODO
			case alertStatus.patrolling:
				transform.Translate(currentDirectionVector * speed[(int)enemyAlertStatus]); // Player movement
			break;
		}
	}
} /* END OF FILE */

