using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyWaveScript : MonoBehaviour 
{

    public int waveNumber; //the wave number
    public int enemiesLeft; //number of enemies currently left in the wave
	public int buttonsSize = 36;
    public float roundDelay; //delay between rounds
    public float spawnMin; //min time to wait until spawning next enemy
    public float spawnMax; //max time to wait until spawning the next enemy
	public GameObject enemyPrefab;
	public GameObject player;
	public Sprite[] anxiousSprites;
	public Sprite[] characterSprites;
	public List<char> buttons = new List<char>(); //List of buttons which can be assigned to the enemy.
//    public char[] buttons;
	public bool gameOver = false;
	GameObject lastEnemy;
	float lastSpawnTime;
	float waitTime; //Actual wait time between spawning enemies between min and max above.
    float roundDelayLeft;
	Vector3 spawnPoint;
	char button;
	int buttonIndex;
		

	void Start()
	{
		waitTime = Random.Range (spawnMin, spawnMax);
        setWave(1);
	}


	void Update()
	{
		if (Time.time > lastSpawnTime + waitTime && !gameOver) 
		{
			if (enemiesLeft >= 1) //there are still enemies to spawn this wave, spawn an enemy
			{
				spawnEnemy ();
				lastSpawnTime = Time.time;
				waitTime = Random.Range (spawnMin, spawnMax);
			}
            else //if there are no enemies left to spawn, we need to progress to the next wave
            {
                //increase delay
                roundDelayLeft += Time.deltaTime;
                if(roundDelayLeft >= roundDelay)
                {
                    //reset time and change wave
                    roundDelayLeft = 0;
                    setWave(++waveNumber);
                }
            }
		}
	}

    void setWave(int waveNumber)
    {
        this.waveNumber = waveNumber;

        enemiesLeft = (int)Mathf.Sqrt(20 * (waveNumber - 1)) + Random.Range(0, 3) + 3; //y = sqrt{20x} + 3 + (random)
        enemyPrefab.GetComponent<EnemyScript>().startSpeed = (Mathf.Sqrt(50 * (waveNumber - 1)) + 50) / 100; //calc speed  y = sqrt{50x}+5

        //TODO add in wave notification
    }

    EnemyScript spawnEnemy()
    {
		if (Random.Range (0, 2) == 1) //Choose a random location to spawn the enemy.
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



		buttonIndex = Random.Range (0, buttonsSize); //Pick a random button from the list of availible buttons.
		button = buttons[buttonIndex];
		buttons.RemoveAt(buttonIndex); //Remove the button from the list.
		buttonsSize--;


		lastEnemy = (GameObject)Instantiate (enemyPrefab, spawnPoint, Quaternion.Euler(new Vector3(90,0,0)));
		lastEnemy.GetComponent<EnemyScript> ().player = player;
		lastEnemy.GetComponent<EnemyScript> ().spawner = this.gameObject;


		lastEnemy.GetComponent<SpriteRenderer>().sprite = anxiousSprites[Random.Range(0,anxiousSprites.Length)]; //Picks a random sprite and applies it to the enemy.





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