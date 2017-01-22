using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour 
{
	public int health; //The player's current health.
	public GameObject audioManager;
	AudioSource[] audio;
	Animator animator;
	int state = 4;


	void Start()
	{
		animator = GetComponent<Animator> ();
		audio = audioManager.GetComponents<AudioSource> ();
	}


	void Update()
	{
		if (health <= 0) 
		{
			print ("You're dead.");
		} else if(health <= 2 && state == 2)
		{
			animator.SetTrigger ("NextState");
			state--;
		} else if(health <= 4 && state == 3)
		{
			animator.SetTrigger ("NextState");
			state--;
		} else if(health <= 6 && state == 4)
		{
			animator.SetTrigger ("NextState");
			state--;
		}

		if (state <= 1) 
		{
			audio [2].volume -= Time.deltaTime/2;
		} else if (state <= 2) 
		{
			audio [1].volume -= Time.deltaTime/2;
		} else if (state <= 3) 
		{
			audio [0].volume -= Time.deltaTime/2;
		}

		if (state == 1)
		{
			audio [3].volume += Time.deltaTime/2;
		} else if (state == 2) 
		{
			audio [2].volume += Time.deltaTime/2;
		} else if (state == 3) 
		{
			audio [1].volume += Time.deltaTime/2;
		}
	}


	void Damage() //Running this function subtracts one health from the player and prints a debug if health is <= 0.
	{
		health -= 1;
		if (health <= 0)
		{
			print ("You dead.");
		}
	}
}