// game object variable
// when the ai shoots a bullet, 

using UnityEngine;
using System.Collections;

public class DT_BulletMovement : MonoBehaviour {

  private Vector3 pos0; // original position
  public Vector3 direction; // set by bullet creation script
  public float speed; // set in GUI
  public float range; // set in GUI
  public JH_Enemy_AI sourceAI;

  // Use this for initialization
  void Start () {

    pos0 = transform.position;

    Debug.Log( direction);
    Debug.Log( direction.magnitude);
  }
  
  // Update is called once per frame
  void Update () {

    Vector3 pos = transform.position;

    if( Vector3.Distance(pos,pos0) > range)
    {
      Destroy( gameObject);
      
      sourceAI.canShoot = true; 
    }

    pos = pos + speed*direction;
    transform.position = pos;


		// Using on collision 2d, 
		// set canShoot back to true.
  


    //Destroy Bullets

 // if (gameObject.collider2D == true){
 //   Destroy (gameObject);
 //   sourceAI.bulletCounter--;
 // }

  }

	void OnTriggerEnter2D( Collider2D other ){			
		sourceAI.canShoot = true;
	}

}
