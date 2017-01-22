using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour 
{
	public GameObject creditsImage;
	public GameObject highScoreImage;

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
		creditsImage.SetActive (true);
	}
	void HighScore()
	{
		highScoreImage.SetActive (true);
	}
}