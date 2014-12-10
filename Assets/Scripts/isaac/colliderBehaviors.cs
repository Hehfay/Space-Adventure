using UnityEngine;
using System.Collections;

public class colliderBehaviors : MonoBehaviour {

	GameObject player;
	GameObject idleColliders;
	//public DT_SpawnPlayer newPlayer;
	public SetHealth gameManager;
	public bool iGrounded;						//to check ground and to have a jumpforce we can change in the editor
	public bool iSqueezedL;
	public bool iSqueezedR;
	public Transform iSqueezeCheckL;
	public Transform iSqueezeCheckR;
	public Transform iGroundCheck;
	GameObject jumpColliders;
	public bool jSqueezedL;
	public bool jSqueezedR;
	public Transform jSqueezeCheckL;
	public Transform jSqueezeCheckR;
	public LayerMask whatIsGround;
	public LayerMask whatCanCrush;
	float groundRadius = 0.06f;
	float squeezeRadius = 0.02f;

	// Use this for initialization
	void Start () {
		idleColliders = GameObject.Find ("idleColliders");
		jumpColliders = GameObject.Find ("jumpColliders");
		player = GameObject.Find ("Player");
		jumpColliders.SetActive (false);
	
	}
	
	// Update is called once per frame
	void Update () {

		//Ground Check
		iGrounded = Physics2D.OverlapCircle (iGroundCheck.position, groundRadius, whatIsGround);	//set our grounded bool

		if (iGrounded && (Input.GetKey (KeyCode.Space) || Input.GetKey ("w"))) {
						idleColliders.SetActive (false);
						jumpColliders.SetActive (true);
				} else {
						jumpColliders.SetActive (false);
						idleColliders.SetActive (true);
				}

		//Squeeze Check while jumping
		iSqueezedL = Physics2D.OverlapCircle (iSqueezeCheckL.position, squeezeRadius, whatCanCrush);
		iSqueezedR = Physics2D.OverlapCircle (iSqueezeCheckR.position, squeezeRadius, whatCanCrush);

		//anim.SetBool ("Squeezed", squeezed);

		if (iSqueezedL && iSqueezedR) {
			//player.SetActive(false);
			//Destroy(player);
			GAMESETTINGS.DEAD = true;
		//	Application.LoadLevel(GAMESETTINGS.CurrentScene);
		}

		if (iGrounded && (Input.GetKey (KeyCode.Space) || Input.GetKey ("w"))) {
			//Squeeze check while jumping
			jSqueezedL = Physics2D.OverlapCircle (jSqueezeCheckL.position, squeezeRadius, whatCanCrush);
			jSqueezedR = Physics2D.OverlapCircle (jSqueezeCheckR.position, squeezeRadius, whatCanCrush);
			if (jSqueezedL && jSqueezedR) {
				//player.SetActive(false);
				//Destroy(player);
				GAMESETTINGS.DEAD = true;

			//	GAMESETTINGS.
			//	Application.LoadLevel(GAMESETTINGS.CurrentScene);
			}
		}
	
	}

	/*void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag ("Bullet")) {
			GAMESETTINGS.PLAYERHEALTH --;
			gameManager.SetHealthText();
			//other.gameObject.SetActive( false );
			if (GAMESETTINGS.PLAYERHEALTH <= 0) {
				GAMESETTINGS.DEAD = true;
			}
		}
	}*/

}
