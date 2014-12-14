using UnityEngine;
using System.Collections;

public class Defuse : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
	public void OnTriggerEnter2D(Collider2D other)
	{
		if (other.collider2D.tag == "Player") {
			Debug.Log("Congratulations! You defused the bomb in time!");
			//Application.LoadLevel();
		}
	}
}
