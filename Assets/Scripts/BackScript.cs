using UnityEngine;
using System.Collections;

public class BackScript : MonoBehaviour 
{
	public GameObject thisMenu;

	void BackToMenu()
	{
		thisMenu.SetActive (false);
	}
}
