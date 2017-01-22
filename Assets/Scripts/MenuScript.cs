using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour 
{
	void StartGame()
	{
		SceneManager.LoadScene ("Level01");
	}
	void QuitGame()
	{
		Application.Quit();
	}
	void Credits()
	{
		print ("Credits.");
	}
	void HighScore()
	{
		print ("High Score");
	}
}