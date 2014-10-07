using UnityEngine;
using System.Collections;

public class IM_Movement : MonoBehaviour {

	public float maxSpeed = 10f;
	public bool facingRight = true;
	Animator anim;						//a value to represent our Animator
	bool grounded;						//to check ground and to have a jumpforce we can change in the editor
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	float jumpForce = 900f;

	// Use this for initialization
	void Start () {
		anim = GetComponent <Animator>();
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);	//set our grounded bool
		anim.SetBool ("Ground", grounded);														//set ground in our Animator to match grounded

		Vector3 pos = transform.position;

		float move = Input.GetAxis ("Horizontal");
		if (move > 0) {
						pos.x = pos.x + 0.1f;
						transform.position = pos;
				}
		if (move < 0) {
						pos.x = pos.x - 0.1f;
						transform.position = pos;
				}
		anim.SetFloat ("Speed",Mathf.Abs (move));												//set our speed

	}
			


	void Update(){
				//if we are on the ground and up was pressed, change our ground state and add an upward force
				if (grounded && Input.GetKeyDown (KeyCode.Space)) {
						anim.SetBool ("Ground", false);
						rigidbody2D.AddForce (new Vector2 (0, jumpForce));
				}

				//Crouching
				if (Input.GetKey("s")) {
						anim.SetBool ("Crouch", true);
				} else
						anim.SetBool ("Crouch", false);
				
		}

	public void flipLeft(){
		facingRight = false;
		Vector3 theScale = transform.localScale;
		theScale.x = -3.549589f;
		transform.localScale = theScale;
	}
	public void flipRight(){
		facingRight = true;
		Vector3 theScale = transform.localScale; 
		theScale.x = 3.549589f;
		transform.localScale = theScale;
	}
}
