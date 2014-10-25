using UnityEngine;
using System.Collections;

public class DT_StickMoevement : MonoBehaviour {

  public GameObject Player;
  private float theta0 = 90.0f; // not sure why this needs to be 90 degrees rather than 0.

  void Start () {
  
  }
  
  void FixedUpdate () {

    Vector3 mouse_pos = Camera.main.ScreenToWorldPoint( Input.mousePosition);

    float x = mouse_pos.x;
    float y = mouse_pos.y;

    float theta;
    float dtheta;

    theta = Mathf.Atan2( x, y) * Mathf.Rad2Deg; // angle of vector pointing at mouse

    dtheta = theta0 - theta; // difference with current angle of stick

    transform.RotateAround( new Vector3(0,0,0), new Vector3(0,0,1), dtheta); // rotate to the new angle

    theta0 = theta; // save the new angle

    // The following flipping mechanism is hardcoded for a fixed position and scale.
    if( x < 0)
    {
      Player.transform.localScale = new Vector3( -3, 3, 1);
      Player.transform.position = new Vector3( -0.15f, 0, 0);
    }
    else
    {
      Player.transform.localScale = new Vector3(  3, 3, 1);
      Player.transform.position = new Vector3( 0.15f, 0, 0);
    }
  
  }
}
