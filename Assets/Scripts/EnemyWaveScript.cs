using UnityEngine;
using System.Collections;

public class EnemyWaveScript : MonoBehaviour 
{

    public int waveNumber; //the wave number
    public int enemiesLeft; //number of enemies currently left in the wave
    public float spawnMin; //min time to wait until spawning next enemy
    public float spawnMax; //max time to wait until spawning the next enemy
	public GameObject enemyPrefab;
	public GameObject player;
	public Sprite[] anxiousSprites;
	public Sprite[] characterSprites;
	public char[] buttons;
	GameObject lastEnemy;
	Vector3 spawnPoint;
	char button;
	int buttonIndex;

    struct EnemyData 
	{
      int speed;
      string button;
    }



	void Update()
	{
		if (enemiesLeft >= 1) 
		{
			spawnEnemy ();
		}
	}



/*    EnemyWaveScript(int waveNumber)
    {
        //assign variables
        this.waveNumber = waveNumber;

        //calculate data based on wave
        enemiesLeft = (int)Mathf.Sqrt(40 * waveNumber) + Random.Range(2, 8) + 15; //y = sqrt{40x} + 15 + (random)
        //TODO calculate other variables and define a default enemy
        //calc speed  y = sqrt{50x}+5
    }
*/


    EnemyScript spawnEnemy()
    {
		if (Random.Range (0, 2) == 1)
		{
			if (Random.Range (0, 2) == 1)
			{
				spawnPoint = new Vector3 (9.5f, 1, Random.Range(-6f,6f));
			} else 
			{
				spawnPoint = new Vector3 (-9.5f, 1, Random.Range(-6f,6f));
			}
		} else 
		{
			if (Random.Range(0, 2) == 1)
			{
				spawnPoint = new Vector3 (Random.Range(-9.5f,9.5f), 1, 6f);
			}else
			{
				spawnPoint = new Vector3 (Random.Range(-9.5f,9.5f), 1, -6f);
			}
		}



		buttonIndex = Random.Range (0, buttons.Length);
		button = buttons[buttonIndex];


		lastEnemy = (GameObject)Instantiate (enemyPrefab, spawnPoint, Quaternion.Euler(new Vector3(90,0,0)));
		lastEnemy.GetComponent<EnemyScript> ().player = player;


		lastEnemy.GetComponent<SpriteRenderer>().sprite = anxiousSprites[Random.Range(0,anxiousSprites.Length)];


		for(int i = 0; i < characterSprites.Length; i++)
		{
			if (""+button == characterSprites[i].name)
			{
				lastEnemy.GetComponent<EnemyScript> ().button = button;
				lastEnemy.transform.GetChild (0).GetComponent<SpriteRenderer> ().sprite = characterSprites[i];
			}
		}


		enemiesLeft--;
		return lastEnemy.GetComponent<EnemyScript> ();
		//TODO spawn enemy
    }
}