using UnityEngine;
using System.Collections;

public class DT_SpawnPlayer : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
		Instantiate(player);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
