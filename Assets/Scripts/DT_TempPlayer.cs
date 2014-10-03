using UnityEngine;
using System.Collections;

public class DT_TempPlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;
		pos.x = pos.x + 0.1f;
		transform.position = pos;
	}

}
