using UnityEngine;
using System.Collections;

public class DT_BulletMovement : MonoBehaviour {

	private Vector3 pos0; // original position
	public Vector3 direction; // set by bullet creation script
	public float speed; // set in GUI
	public float range; // set in GUI

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
		}

		//pos.x = pos.x + 0.1f;
		pos = pos + speed*direction;
		transform.position = pos;


		//Destroy Bullets

		if (gameObject.collider2D == true){
			//	Destroy (gameObject);
		}

	}
}
