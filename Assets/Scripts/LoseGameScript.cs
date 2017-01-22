using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoseGameScript : MonoBehaviour 
{
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