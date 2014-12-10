// IM_PlayerMovement.cs Script
// This script creates movement for the player including walking 
// and running left and right as well as jumping and crouching. The 
// animator is referenced and manipulated whenever the character is 
// running, jumping or crouching.
//
// -Written by Isaac Meisner

using UnityEngine;
using System.Collections;

public class IM_PlayerMovement : MonoBehaviour {

	public colliderBehaviors colliders;
	//public UIManagerScript pausing;
	public bool facingRight = true;
	float jumpForce = 14f;
	float sprintJumpLength = 150f;
	float sprintJumpHeight = 50f;
	float walkingIncrement = 0.09f;
	float sprintingIncrement = 0.13f;
	int jumpCount;
	Animator anim;								//a value to represent our Animator

	// Use this for initialization
	void Start () {
		anim = GetComponent <Animator>();
	}

	void Update () {
		
		anim.SetBool ("Moving", false);
		Vector3 pos = transform.position;
		
		if (colliders.iGrounded) {
			anim.SetBool ("Ground", colliders.iGrounded);								//set ground in our Animator to match grounded
		}


		if(!(GAMESETTINGS.PAUSED)){
			//Walking to the right
			if (Input.GetKey ("d")) {
				anim.SetBool ("Moving", true);
				if(colliders.iGrounded && (Input.GetKey (KeyCode.LeftShift))) {
					pos.x += sprintingIncrement;
				}
				else {
					pos.x += walkingIncrement;
				}
				transform.position = pos;
			}
			
			//Walking to the left
			if (Input.GetKey ("a")) {
				anim.SetBool ("Moving", true);
				if(colliders.iGrounded && (Input.GetKey(KeyCode.LeftShift))) {
					pos.x -= sprintingIncrement;
				}
				else {
					pos.x -= walkingIncrement;
				}
				transform.position = pos;
			}
		}
	}

	void FixedUpdate () {

		//Jumping
		//If we are on the ground and up was pressed, change our ground state and add an upward force
		if (colliders.iGrounded && (Input.GetKey (KeyCode.Space) || Input.GetKey("w"))) {
				anim.SetBool ("Ground", false);
				rigidbody2D.AddForce (new Vector2 (0, jumpForce), ForceMode2D.Impulse);
		}

		//Sprinting then Jumping
		//If the character is on the ground and sprinting, add large upward force
		if (colliders.iGrounded){
			if (Input.GetKey (KeyCode.Space)){
				anim.SetBool ("Ground", false);
				if (Input.GetKey (KeyCode.LeftShift) && (Input.GetKey ("a"))) {
					rigidbody2D.AddForce (new Vector2 (-sprintJumpLength, sprintJumpHeight));
				}
				if (Input.GetKey (KeyCode.Space) && Input.GetKey (KeyCode.LeftShift) && (Input.GetKey ("d"))) {
					rigidbody2D.AddForce (new Vector2 (sprintJumpLength, sprintJumpHeight));
				}
			}
		}
	}

}
