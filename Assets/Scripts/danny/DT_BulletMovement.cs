// game object variable
// when the ai shoots a bullet, 

using UnityEngine;
using System.Collections;

public class DT_BulletMovement : MonoBehaviour {

	private Vector3 pos0; // original position
	public Vector3 direction; // set by bullet creation script
	public float speed; // set in GUI
	public float range; // set in GUI
	bool enemy_can_fire = true;
	public JH_Enemy_AI sourceAI;

	// Use this for initialization
	void Start () {

		pos0 = transform.position;

		Debug.Log( direction);
		Debug.Log( direction.magnitude);
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 pos = transform.position;

		if( Vector3.Distance(pos,pos0) > range)
		{
			Destroy( gameObject);
			enemy_can_fire = true;
			
			sourceAI.bulletCounter--; 
		}

		if( enemy_can_fire )
		{
			//pos.x = pos.x + 0.1f;
			pos = pos + speed*direction;
			transform.position = pos;
			enemy_can_fire = false;
		}
		


		//Destroy Bullets

		if (gameObject.collider2D == true){
			//	Destroy (gameObject);
		}

	}
}
