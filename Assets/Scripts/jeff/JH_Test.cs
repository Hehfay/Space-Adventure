//Define how the enemy looks around for various states
/******************************************************************************/ 
/* If the enemy is in attack mode, make the enemy look at the player.  				*/
/* We may want this function to return a sight vector so we can pass it to an */ 
/* enemy shoot function.																										*/
/******************************************************************************/  
/* 
void lookAround()
{
/	switch ( enemyAlertStatus )
	{
		case alertStatus.attacking:
			lineofSight = Physics2d.Raycast ( transform.position
																			,	fireTo.transform.position
																			, 10
																			, whatToHit );
			break;

		case alertStatus.standing:
		case alertStatus.casualPatrol:
		case alertStatus.patrolling:
			lineOfSight = Physics2D.Raycast ( transform.position 
																					, transform.TransformDirection(currentDirectionVector)
																					, 10
																					, whatToHit );	
			break;
	}
}


*/










