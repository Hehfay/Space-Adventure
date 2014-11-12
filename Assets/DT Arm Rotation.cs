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
	transform.localScale = new Vector3(  -scaleOfArm,  -scaleOfArm, 1);
	
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
