using UnityEngine;
using System.Collections;

public class LB_DeathTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	
	}
	public void OnTriggerEnter2D(Collider2D other)
	{
		if (other.collider2D.tag == "Player") {
			Debug.Log("You are dead.");

				}
	}
}
