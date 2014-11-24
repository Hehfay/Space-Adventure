using UnityEngine;
using System.Collections;

public class MaxandMinDeath : MonoBehaviour {

	public Vector2 Max;
	public Vector2 Min;
	float maxArea;
	float minArea;
	
	private Transform m_objectTransform;
	
	// Use this for initialization
	void Start () {	
	  maxArea = Max.x * Max.y;
		minArea = Min.x * Min.y;
		m_objectTransform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {

		if( m_objectTransform.localScale.y * m_objectTransform.localScale.x >= maxArea ||
			  m_objectTransform.localScale.y * m_objectTransform.localScale.x <= minArea)
		{
			Destroy( gameObject );
		}

	}
}
