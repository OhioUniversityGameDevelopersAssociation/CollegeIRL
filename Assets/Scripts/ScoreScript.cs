using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour 
{
	public GameObject[] scoreTexts; //The UI elements that display the score text.
	int[] scores = {0,0,0,0,0,0,0,0,0,0,0};
	int isInOrder = 1;

	void Start()
	{
		addScores ();

		for(int i = 0; i < 10; i++)
		{
			scoreTexts [i].GetComponent<Text> ().fontSize = ((Screen.height / 1080) * 35);
		}
	}


	void Update()
	{
		organizeScores ();


		for (int i = 0; i < 10; i++) 
		{
			scoreTexts [i].GetComponent<Text> ().text = ""+scores[i];
		}
	}


	void addScore (int score, int index) //Adds int score to array scores at location index.
	{
		scores [index] = score;
	}


	void addScores() //Adds all scores in PlayerPrefs to the scores array.
	{
		for (int i = 0; i < 11; i++) 
		{
			if (PlayerPrefs.GetInt("Score"+i) != 0)
			{
				addScore(PlayerPrefs.GetInt("Score"+i),i);
			}
		}
	}


	void organizeScores() //Orders the scores from greaest to least.
	{
		while (isInOrder != 0)
		{
			isInOrder = 0;
			for (int i = 9; i >= 0; i--) 
			{
				if (scores [i + 1] > scores [i]) 
				{
					int temp = scores [i + 1];
					scores [i + 1] = scores [i];
					scores [i] = temp;
					isInOrder++;
				}
			}
		}
	}
}