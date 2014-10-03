using UnityEngine;
using System.Collections;

public class Enemy_AI : MonoBehaviour 
{
	Vector2 sightDirection;

	private enum directions
	{
		left,
		right
	};
	private directions currentDirection;

	private enum alertStatus
	{
		patroling,
		attacking
	};
	private alertStatus enemyAlertStatus;

	// Use this for initialization
	void Start() 
	{
		currentDirection = directions.right;
	}
	
	// Update is called once per frame
	void Update () 
	{
		switch ( currentDirection ){
			case directions.left:
				Physics2D.Raycast (transform.position, sightDirection);
				transform.Translate(Vector3.left * 0.05f);
				break;
			case directions.right:
				transform.Translate(Vector3.right * 0.05f);
				Physics2D.Raycast (transform.position, sightDirection);
				break;
		}
	}

	void OnDrawGizmos(){
		Vector2 direction = new Vector2 (5, 0);
		Gizmos.color = Color.red;
		Gizmos.DrawLine (transform.position, direction);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Left")
		{
			currentDirection = directions.right;
			sightDirection = new Vector2(1,0);
		}
		if(other.gameObject.tag == "Right")
		{
			currentDirection = directions.left;
			sightDirection = new Vector2(-1,0);
		}
	}
}

