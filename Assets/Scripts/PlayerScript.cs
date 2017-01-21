using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour 
{
	public int health; //The player's current health.

	void Damage() //Running this function subtracts one health from the player and prints a debug if health is <= 0.
	{
		health -= 1;
		if (health <= 0)
		{
			print ("You dead.");
		}
	}
}