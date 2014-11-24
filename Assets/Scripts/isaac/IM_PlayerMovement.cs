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
	bool isJumping;
	public bool squeezedL;
	public bool squeezedR;
	public Transform groundCheck;
	public Transform squeezeCheckL;
	public Transform squeezeCheckR;
	public LayerMask whatIsGround;
	public LayerMask whatCanCrush;
	float groundRadius = 0.1f;
	float squeezeRadius = 0.15f;
	float jumpForce = 700f;
	float sprintJumpLength = 50f;
	float sprintJumpHeight = 25f;
	float walkingIncrement = 0.09f;
	float sprintingIncrement = 0.13f;
	public GUIText healthText;
	private int healthCount;
	public GUIText pickupText;
	private int pickupCount;
	public DT_SpawnPlayer reload;
	public Transform playerInfo;

	// Use this for initialization
	void Start () {
		anim = GetComponent <Animator>();
		healthCount = 10;
		pickupCount = 0;
		SetHealthText ();
	}
	
	void Update () {

		//Ground Check
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);	//set our grounded bool
		anim.SetBool ("Ground", grounded);								//set ground in our Animator to match grounded

		//Sprinting then Jumping
		//If the character is on the ground and sprinting, add large upward force
		if (grounded && (Input.GetKey(KeyCode.Space) && Input.GetKey (KeyCode.LeftShift) && (Input.GetKey ("a") || Input.GetKey ("d")))) {
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
		if (grounded && (Input.GetKey (KeyCode.Space) || Input.GetKey ("w"))) {
			anim.SetBool ("Ground", false);
			//isJumping = true;
			rigidbody2D.AddForce (new Vector2 (0, jumpForce));
		}

		//spawnPoint.Set (-6.06003f, -1.113014f, 0.0f);
		//Squeeze Check
		squeezedL = Physics2D.OverlapCircle (squeezeCheckL.position, squeezeRadius, whatCanCrush);
		squeezedR = Physics2D.OverlapCircle (squeezeCheckR.position, squeezeRadius, whatCanCrush);
		//anim.SetBool ("Squeezed", squeezed);
		if (squeezedL && squeezedR) {
			renderer.enabled = false;
			Instantiate(playerInfo,reload.transform.position,Quaternion.identity);
				}
		
		//Moving
		anim.SetBool ("Moving", false);									//Initialize the Moving animation
		Vector3 pos = transform.position;
        
        
		//Walking to the right
		if (Input.GetKey ("d")) {
			anim.SetBool ("Moving", true);
			if(grounded && (Input.GetKey (KeyCode.LeftShift))) {
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
			if(grounded && (Input.GetKey(KeyCode.LeftShift))) {
				pos.x -= sprintingIncrement;
			}
			else {
				pos.x -= walkingIncrement;
			}
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
		
	//void FixedUpdate{
	//	if(isJumping){
	//		rigidbody2D.AddForce (new Vector2 (0, jumpForce));
	//	}
	//}



	void SetHealthText(){
			healthText.text = "Health: " + healthCount.ToString ();
		}
	void SetPickupText(){
			pickupText.text = "Pickups: " + pickupCount.ToString ();
		}

	void OnTriggerEnter2D(Collider2D other){
				if (other.CompareTag("Bullet")) {
						healthCount--;
						SetHealthText ();
//						other.gameObject.SetActive( false );
						Destroy( other.gameObject );
						if( healthCount <= 0 ){
							Destroy( gameObject );
						}
				}
				if (other.CompareTag("Pickup")) {
						other.gameObject.SetActive (false);
						pickupCount++;
				}
					

		}


}
