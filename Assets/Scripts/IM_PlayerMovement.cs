/// IM_PlayerMovement.cs Script
/// This script creates movement for the player including running
/// left and right as well as jumping and crouching. The animator
/// is referenced and manipulated whenever the character is running
/// jumping or crouching.
/// 
/// -Written by Isaac Meisner

using UnityEngine;
using System.Collections;

public class IM_PlayerMovement : MonoBehaviour {
	
	Animator anim;						//a value to represent our Animator
	bool grounded;						//to check ground and to have a jumpforce we can change in the editor
	public Transform groundCheck;
	float groundRadius = 0.1f;
	public LayerMask whatIsGround;
	float jumpForce = 900f;
	public float speedForce = 10f;
	public bool facingRight = true;
	float scaleOfPlayer = 3.549589f;
	float positionShift = 0.3830832f;

	// Use this for initialization
	void Start () {
		anim = GetComponent <Animator>();
	
	}
	
	void FixedUpdate () {
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);	//set our grounded bool
		anim.SetBool ("Ground", grounded);														//set ground in our Animator to match grounded

		Vector3 pos = transform.position;

		anim.SetBool ("Moving", false);									//Initialize the Moving animation

		if (Input.GetKey ("d")) {
			anim.SetBool ("Moving", true);
			pos.x += 0.1f;
			transform.position = pos;
		}
		if (Input.GetKey ("a")) {
			anim.SetBool ("Moving", true);	
			pos.x -= 0.1f;
			transform.position = pos;
		}

	}
			
	// Update is called once per frame
	void Update(){

		//Jumping
		//if we are on the ground and up was pressed, change our ground state and add an upward force
				if (grounded && Input.GetKeyDown (KeyCode.Space)) {
						anim.SetBool ("Ground", false);
						rigidbody2D.AddForce (new Vector2 (0, jumpForce));
				}

		//Crouching
		anim.SetBool ("Crouch", false);		
		if (Input.GetKey("s")) {
				anim.SetBool ("Crouch", true);
			}
				
		}

	public void flipLeft(){
		facingRight = false;
		Vector3 theScale = transform.localScale;
		theScale.x = -scaleOfPlayer;
		Vector3 pos = transform.position;
		pos.x -=  positionShift;
		transform.position = pos;
		transform.localScale = theScale;
	}
	public void flipRight(){
		facingRight = true;
		Vector3 theScale = transform.localScale; 
		theScale.x = scaleOfPlayer;
		Vector3 pos = transform.position;
		pos.x +=  positionShift;
		transform.position = pos;
		transform.localScale = theScale;
	}

}
