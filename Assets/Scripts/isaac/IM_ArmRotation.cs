// IM_ArmRotation.cs Script
// This script rotates the arm of the player to point
// at the position of the mouse. When the mouse goes on the
// other side of where the player is facing, the player
// is flipped. The scale and a position shift variable
// are included to make the flipping look smoother.
//
// -Written by Isaac Meisner

using UnityEngine;
using System.Collections;

public class IM_ArmRotation : MonoBehaviour {

  public IM_PlayerMovement player;
  Vector3 gunDir;
  float positionShift;
  float scaleOfPlayer = 3.549589f;
  float scaleOfArm = 0.8f;
  float theta;

  void FixedUpdate () {

    positionShift = 0.57f;

    gunDir = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position;
    gunDir.Normalize (); // normalize the vector

    float dx = gunDir.x;
    float dy = gunDir.y;

    // angle of arm in degrees
    float theta = Mathf.Atan2 (dy, dx) * Mathf.Rad2Deg;

    if( Mathf.Abs(theta) > 90) { theta = -theta;} // because player is flipped

    // Debug.Log(theta);
    
    if( ( theta > 90 || theta < -90) && player.facingRight )
    {
      //Flip left
      transform.localScale = new Vector3(  -scaleOfArm,  scaleOfArm, 1);

      player.transform.localScale = new Vector3( -scaleOfPlayer
                                               , scaleOfPlayer
                                               , 1);

      Vector3 pos = player.transform.position;
      pos.x -=  positionShift;
      player.transform.position = pos;

      player.facingRight = false;
    }
    if( ( theta < 90 && theta > -90) && !player.facingRight )
    {
      //Flip right
      transform.localScale = new Vector3(  scaleOfArm,  scaleOfArm, 1);

      player.transform.localScale = new Vector3( scaleOfPlayer
                                               , scaleOfPlayer
                                               , 1);

      Vector3 pos = player.transform.position;
      pos.x +=  positionShift;
      player.transform.position = pos;

      player.facingRight = true;
    }
  
    transform.localRotation = Quaternion.Euler (0f, 0f, theta);

    /*Vector2 mouse = Camera.main.ScreenToViewportPoint (Input.mousePosition);
    Vector3 objpos = Camera.main.WorldToViewportPoint (transform.position);
    Vector2 relobjpos = new Vector2 (objpos.x - 0.5f, objpos.y - 0.5f);
    Vector2 relmousepos = new Vector2 (mouse.x - 0.5f, mouse.y - 0.5f) - relobjpos;
    float angle = Vector2.Angle (Vector2.up, relmousepos);
    if (relmousepos.x > 0)
            angle = 360 - angle;
    Quaternion quat = Quaternion.identity;
    angle += 90;
    quat.eulerAngles = new Vector3 (0, 0, (angle));
    transform.rotation = quat;

    if((angle > 90.0f && angle < 270.0f) && (player.facingRight == true)){
      Vector3 pos = player.transform.position;
      pos.x -= positionShift;
      player.transform.position = pos;
      player.facingRight = false;
      float yrot = 180.0f;
      Quaternion roatio = player.transform.localRotation;
      roatio.y = yrot;
      player.transform.localRotation = roatio;
    }

    if((angle > 270.0f && angle < 450.0f) && (player.facingRight == false)){
      Vector3 pos = player.transform.position;
      pos.x += positionShift;
      player.transform.position = pos;
      player.facingRight = true;
      float yrot = 0.0f;
      Quaternion roatio = player.transform.localRotation;
      roatio.y = yrot;
      player.transform.localRotation = roatio;
    }*/

  }
}









