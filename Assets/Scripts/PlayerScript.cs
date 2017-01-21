using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour 
{
	public int health;

	void Damage()
	{
		health -= 1;
		if (health <= 0)
		{
			print ("You dead.");
		}
	}
}