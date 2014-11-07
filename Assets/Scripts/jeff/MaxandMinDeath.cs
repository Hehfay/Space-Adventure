using UnityEngine;
using System.Collections;

public class MaxandMinDeath : MonoBehaviour {

	public Vector2 Max;
	public Vector2 Min;
	float maxArea;
	float minArea;
	
	// Use this for initialization
	void Start () {	
	  maxArea = Max.x * Max.y;
	}
	
	// Update is called once per frame
	void Update () {

		if( gameObject.transform.localScale.y * gameObject.transform.localScale.x >= maxArea ||
			  gameObject.transform.localScale.y * gameObject.transform.localScale.x <= minArea)
		{
			Destroy( gameObject );
		}

	}
}
