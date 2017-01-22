using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoseGameScript : MonoBehaviour 
{
	public GameObject scoreText;
	public GameObject player;
	int[] scores = {0,0,0,0,0,0,0,0,0,0,0};
	int isInOrder = 1;

	void Start()
	{
		scoreText.GetComponent<Text>().text = "Score: " + player.GetComponent<PlayerScript> ().score;

		addScores ();

		scoreText.GetComponent<Text> ().fontSize = ((Screen.height / 1080) * 35);
	}


	void Update()
	{
		organizeScores ();

		storeScores ();
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


	void storeScores() //Saves the scores in the array scores to the playerPrefs.
	{
		for (int i = 0; i < 10; i++)
		{
			PlayerPrefs.SetInt ("Score" + i, scores [i]);
		}
	}



	void QuitGame()
	{
		Application.Quit ();
	}
	void BackToMenu()
	{
		SceneManager.LoadScene ("Menu");
	}
	void RestartLevel()
	{
		SceneManager.LoadScene ("Level01");
	}
}