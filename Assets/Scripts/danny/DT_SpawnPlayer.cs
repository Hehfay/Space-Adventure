using UnityEngine;
using System.Collections;

public class DT_SpawnPlayer : MonoBehaviour {

	public	GameObject player;
	public string ifPrevScene;
	private string previousScene;

	// Use this for initialization
	void Start () {
		
		previousScene=GAMESETTINGS.PREVIOUS_SCENE;
		if( ifPrevScene == previousScene){
			Instantiate(player,transform.position,Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
