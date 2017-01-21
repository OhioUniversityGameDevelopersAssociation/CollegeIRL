using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour 
{
	public GameObject player;
	public Vector3 startPos;
	public int health;
	public bool buttonHeld;
	public float startSpeed;
	public char button;
	float fractJourney = 0.01f;
	float speed;

	void Start ()
	{
		startPos = transform.position;
		speed = startSpeed;
	}
	void Update () 
	{
		if (Input.GetButton(""+button) )
		{
			buttonHeld = true;
			print ("Button pressed");
		} else
		{
			buttonHeld = false;
		}

		if(buttonHeld == false)
		{
			speed = startSpeed;
		} else if(buttonHeld == true)
		{
			speed = startSpeed * -1;
		}

		fractJourney += speed * Time.deltaTime;
		transform.position = Vector3.Lerp(startPos, player.transform.position, fractJourney);

		if (Vector2.Distance (new Vector2 (transform.position.x, transform.position.z), new Vector2 (player.transform.position.x, player.transform.position.z)) <= 1)
		{
			print ("You took damage.");
			player.SendMessage ("Damage");
			Destroy (gameObject);
		}
	}
}