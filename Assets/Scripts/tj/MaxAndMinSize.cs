using UnityEngine;
using System.Collections;

public class MaxAndMinSize : MonoBehaviour {

	public Vector2 Max;
	public Vector2 Min;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	//Max Size
		if(gameObject.transform.localScale.y >= Max.y-.1){
	//		transform.localScale = Max;
		}
		if(gameObject.transform.localScale.x >= Max.x-.1){
	//		transform.localScale = Max;
		}
	
	//Min Size
		if(gameObject.transform.localScale.y <= Min.y+.1){
	//		gameObject.transform.localScale = Min;
		}
		
		if(gameObject.transform.localScale.x <= Min.x+.1){
	//		gameObject.transform.localScale = Min;
		}
	}
}
