// IM_PlayerMovement.cs Script
// This script creates movement for the player including walking 
// and running left and right as well as jumping and crouching. The 
// animator is referenced and manipulated whenever the character is 
// running, jumping or crouching.
// 
// -Written by Isaac Mei sner

using UnityEngine;
using System.Collections;

public class IM_PlayerMovement : MonoBehaviour {

	Animator anim;								//a value to represent our Animator
	public bool grounded;						//to check ground and to have a jumpforce we can change in the editor
	public bool facingRight = true;
	public bool squeezed;
	public Transform groundCheck;
	public Transform squeezeCheck;
	public LayerMask whatIsGround;
	public LayerMask whatCanCrush;
	float groundRadius = 0.1f;
	float squeezeRadius = 0.15f;
	float jumpForce = 725f;
	float walkingIncrement = 0.09f;
	float sprintingIncrement = 0.1f;

	// Use this for initialization
	void Start () {
		anim = GetComponent <Animator>();
	}
	
	void FixedUpdate () {

		//Ground Check
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);	//set our grounded bool
		anim.SetBool ("Ground", grounded);								//set ground in our Animator to match grounded

		//Squeeze Check
		squeezed = Physics2D.OverlapCircle (squeezeCheck.position, squeezeRadius, whatCanCrush);
		//anim.SetBool ("Squeezed", squeezed);
		if(squeezed)
			Debug.Log (squeezed);
		
		//Moving
		anim.SetBool ("Moving", false);									//Initialize the Moving animation
		Vector3 pos = transform.position;

		//Walking to the right
		if (Input.GetKey ("d")) {
			anim.SetBool ("Moving", true);
			pos.x += walkingIncrement;
			transform.position = pos;
		}

		//Sprinting to the right 
		if (grounded && (Input.GetKey ("d") && Input.GetKey (KeyCode.LeftShift))) {
			anim.SetBool ("Moving", true);
			pos.x += sprintingIncrement;
			transform.position = pos;
		}

		//Walking to the left
		if (Input.GetKey ("a")) {
			anim.SetBool ("Moving", true);	
			pos.x -= walkingIncrement;
			transform.position = pos;
		}

		//Sprinting to the right
		if (grounded && (Input.GetKey ("a") && Input.GetKey (KeyCode.LeftShift))) {
			anim.SetBool ("Moving", true);	
			pos.x -= sprintingIncrement;
			transform.position = pos;
		}

		//If both right and left are pushed
		if(Input.GetKey ("a") && Input.GetKey("d")){						
			//pos.x += walkingIncrement;
			//transform.position = pos;
		}


		//Jumping
		//If we are on the ground and up was pressed, change our ground state and add an upward force
		if (grounded && (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown ("w"))) {
			anim.SetBool ("Ground", false);
			rigidbody2D.AddForce (new Vector2 (0, jumpForce));
		}
		
		//Crouching
		anim.SetBool ("Crouch", false);		
		if (Input.GetKey("s")) {
			anim.SetBool ("Crouch", true);
		}
		
		//Crouch Walking Right
		if (Input.GetKey("s") && Input.GetKey("d")) {
			//Crouch walking animation
			/*
			 * pos.x += walkingIncrement;
			 * transform.position = pos;
			 */
		}
		if(Input.GetKey("s") && Input.GetKey("a")){
			//Crouch walking animation
			/*
			 * pos.x -= walkingIncrement;
			 * transform.position = pos;
			 */
		}

	}
			
	// Update is called once per frame
	void Update(){

	}

	/*public void flipLeft(){
		facingRight = false;
		Vector3 theScale = transform.localScale;
		theScale.x = -scaleOfPlayer;
		Vector3 pos = transform.position;
		pos.x -=  positionShift;
		transform.position = pos;
		transform.localScale = theScale;
		Debug.Log ("Flip left");
	}
	public void flipRight(){
		facingRight = true;
		Vector3 theScale = transform.localScale; 
		theScale.x = scaleOfPlayer;
		Vector3 pos = transform.position;
		pos.x +=  positionShift;
		transform.position = pos;
		transform.localScale = theScale;
		Debug.Log ("Flip Right");

	}*/
}
