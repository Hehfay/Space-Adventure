using UnityEngine;
using System.Collections;

public class ShotScript : MonoBehaviour {


	public int damage = 1;
	public bool isEnemyShot = false;
	public Camera camera;
	private float speed=20f;
	private Vector2 clickPos;
	// Use this for initialization
	void Start () {
	
		Destroy(gameObject,20);
		camera =(Camera) GameObject.FindObjectOfType(typeof(Camera));
		clickPos=camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetMouseButtonDown(0)){
			Vector3 shotDir=((Vector3)clickPos-transform.position).normalized;
			gameObject.rigidbody2D.velocity=shotDir;
		}
	
	}
}
