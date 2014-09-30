using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	// The force which is added when the player jumps
	// This can be changed in the Inspecor window
	
	public Vector3 jumpForce = new Vector2 (0,300);
	public float speed;
	public GUIText countText;
	public GUIText WinText;
	private int count;
	
	void Start(){
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		if(Input.GetKeyUp("space"))
		{
			rigidbody2D.velocity = Vector2.zero;
			rigidbody2D.AddForce(jumpForce);
		}
		float move = Input.GetAxis ("Horizontal");
		rigidbody2D.velocity = new Vector2 (move * speed * Time.deltaTime, rigidbody2D.velocity.y);
		
		
		
	}

	
}
