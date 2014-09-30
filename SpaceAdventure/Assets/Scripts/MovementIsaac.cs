using UnityEngine;
using System.Collections;

public class MovementIsaac : MonoBehaviour {

	public float maxSpeed = 10f;
	bool facingRight = true;
	Animator anim;						//a value to represent our Animator
	bool grounded = false;				//to check ground and to have a jumpforce we can change in the editor
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public float jumpForce = 700f;

	// Use this for initialization
	void Start () {
		anim = GetComponent <Animator>();
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);	//set our grounded bool
		anim.SetBool ("Ground", grounded);														//set ground in our Animator to match grounded

		anim.SetFloat ("vSpeed", rigidbody2D.velocity.y);										//set our vSpeed

		float move = Input.GetAxis ("Horizontal");
		rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y);
		anim.SetFloat ("Speed",Mathf.Abs (move));												//set our speed

				
		if(move > 0 && !facingRight)
			Flip();
		else if(move < 0 && facingRight)
			Flip();
	}
			


	void Update(){
		//if we are on the ground and the space bar was pressed, change our ground state and add an upward force
		if(grounded && Input.GetKeyDown (KeyCode.Space)){
			anim.SetBool("Ground",false);
			rigidbody2D.AddForce (new Vector2(0,jumpForce));
		}
	}

	void Flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

}


