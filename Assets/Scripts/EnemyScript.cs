using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour 
{
	public GameObject player;
	public Vector3 startPos;
	public float startSpeed;
	public char button; //Assigned button you must press to move the enemy away, assigned by the spawning script.
	float fractJourney = 0.01f; //Starts the player 1% of the way toward the player so that it isn't destroyed on spawn.
	float speed; //Speed of the player in percent of distanced traveled per second. e.g. 0.50 is the enemy will move 50% of the way to the player each second.

	void Start ()
	{
		startPos = transform.position;
		speed = startSpeed;
	}
	void Update () 
	{
		if (Input.GetButton(""+button) ) //Checks if the assigned button is pressed and if so moves away from the player, if not, moves toward him.
		{
			speed = -startSpeed;
		} else
		{
			speed = startSpeed;
		}

		fractJourney += speed * Time.deltaTime;
		transform.position = Vector3.Lerp(startPos, player.transform.position, fractJourney); //Moves the enemy fractJourney percent of the way toward/away from the player.

		if (Vector2.Distance (new Vector2 (transform.position.x, transform.position.z), new Vector2 (player.transform.position.x, player.transform.position.z)) <= 1) //If the enemy is close enough to the player, run the damage function on the player.
		{
			player.SendMessage ("Damage");
			Destroy (gameObject);
		}

		if (transform.position == startPos) 
		{
			Destroy (gameObject);
		}
	}
}