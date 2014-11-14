using UnityEngine;
using System.Collections;

public class DT_SpawnPlayer : MonoBehaviour {

	public GameObject player;
	public string currentDoor;
	string previousDoor;

	// Use this for initialization
	void Start () {
		
		previousDoor=GAMESETTINGS.PreviousDoor;
		if(GAMESETTINGS.CurrentScene=="00_00StartScene" && previousDoor =="none"){
			Instantiate(player,transform.position,Quaternion.identity);
		}
		else if(previousDoor != currentDoor && previousDoor!= "none"){
			Instantiate(player,transform.position,Quaternion.identity);
			}
					Debug.Log( "previousDoor: " + previousDoor );

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
