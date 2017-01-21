using UnityEngine;
using System.Collections;

public class EnemyMoveScript : MonoBehaviour 
{
	public GameObject player;
	public Vector3 startPos;
	public int health;
	public bool buttonHeld;
	public float speed;
	float startTime;
	float journeyLength;
	float disCovered;
	float fractJourney;

	void Start ()
	{
		startTime = Time.time;
		startPos = transform.position;
		journeyLength = Vector3.Distance (startPos, player.transform.position);
	}
	void Update () 
	{
		if(health > 0 && buttonHeld == false)
		{
			disCovered = (Time.time - startTime) * speed;
			fractJourney = disCovered / journeyLength;
			transform.position = Vector3.Lerp(startPos, player.transform.position, fractJourney);
		}

		if (Vector2.Distance (new Vector2 (transform.position.x, transform.position.z), new Vector2 (player.transform.position.x, player.transform.position.z)) <= 1)
		{
			print ("You took damage.");
			player.SendMessage ("Damage");
			Destroy (gameObject);
		}
	}
}