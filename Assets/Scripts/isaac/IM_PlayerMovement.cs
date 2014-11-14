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

	Animator anim;								//a value to represent our Animator
	public bool grounded;						//to check ground and to have a jumpforce we can change in the editor
	public bool facingRight = true;
	public bool squeezedL;
	public bool squeezedR;
	public Transform groundCheck;
	public Transform squeezeCheckL;
	public Transform squeezeCheckR;
	public LayerMask whatIsGround;
	public LayerMask whatCanCrush;
	float groundRadius = 0.1f;
	float squeezeRadius = 0.15f;
	float jumpForce = 725f;
	float sprintJumpLength = 100f;
	float sprintJumpHeight = 100f;
	float walkingIncrement = 0.09f;
	float sprintingIncrement = 0.1f;
	public GUIText healthText;
	private int healthCount;
	public GUIText pickupText;
	private int pickupCount;
	//public DT_DemoDoor respawn;
	//Vector3 spawnPoint;
	public int levelNumber = 3;

	// Use this for initialization
	void Start () {
		anim = GetComponent <Animator>();
		healthCount = 10;
		pickupCount = 0;
		SetHealthText ();
	}
	
	void FixedUpdate () {

		//Ground Check
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);	//set our grounded bool
		anim.SetBool ("Ground", grounded);								//set ground in our Animator to match grounded

		//Sprinting then Jumping
		//If the character is on the ground and sprinting, add large upward force
		if (grounded && (Input.GetKeyDown(KeyCode.Space) && Input.GetKey (KeyCode.LeftShift) && (Input.GetKey ("a") || Input.GetKey ("d")))) {
			anim.SetBool ("Ground", false);
			if(facingRight){
				rigidbody2D.AddForce (new Vector2 (sprintJumpLength, sprintJumpHeight));
			}
			if (!facingRight){
				rigidbody2D.AddForce (new Vector2(-sprintJumpLength, sprintJumpHeight));
			}
		}

		//Jumping
		//If we are on the ground and up was pressed, change our ground state and add an upward force
		if (grounded && (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown ("w"))) {
			anim.SetBool ("Ground", false);
			rigidbody2D.AddForce (new Vector2 (0, jumpForce));
		}

		//spawnPoint.Set (-6.06003f, -1.113014f, 0.0f);
		//Squeeze Check
		squeezedL = Physics2D.OverlapCircle (squeezeCheckL.position, squeezeRadius, whatCanCrush);
		squeezedR = Physics2D.OverlapCircle (squeezeCheckR.position, squeezeRadius, whatCanCrush);
		//anim.SetBool ("Squeezed", squeezed);
		if (squeezedL && squeezedR) {
			renderer.enabled = false;
			Application.LoadLevel(levelNumber);
			//transform.position = spawnPoint;
			//renderer.enabled = true;
				}
		
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

		
		//Crouching
		//anim.SetBool ("Crouch", false);		
		//if (Input.GetKey("s")) {
		//	anim.SetBool ("Crouch", true);
		//}
		
		//Crouch Walking Right
		//if (Input.GetKey("s") && Input.GetKey("d")) {
			//Crouch walking animation
			/*
			 * pos.x += walkingIncrement;
			 * transform.position = pos;
			 */
		//}
		//if(Input.GetKey("s") && Input.GetKey("a")){
			//Crouch walking animation
			/*
			 * pos.x -= walkingIncrement;
			 * transform.position = pos;
			 */
		//}

	}
		

	void SetHealthText(){
			healthText.text = "Health: " + healthCount.ToString ();
		}
	void SetPickupText(){
			pickupText.text = "Pickups: " + pickupCount.ToString ();
		}

	void OnTriggerEnter2D(Collider2D other){
				if (other.gameObject.tag == "Bullet") {
						healthCount--;
						SetHealthText ();
//						other.gameObject.SetActive( false );
						Destroy( other.gameObject );
				}
				if (other.gameObject.tag == "Pickup") {
						other.gameObject.SetActive (false);
						pickupCount++;
				}
					

		}


}
