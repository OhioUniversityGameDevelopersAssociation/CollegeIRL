using UnityEngine;
using System.Collections;

public class EnemyWaveScript : MonoBehaviour 
{

    public int waveNumber; //the wave number
    public int enemiesLeft; //number of enemies currently left in the wave
<<<<<<< HEAD
    public float minSpawnTime; //min time to wait until spawning next enemy
    public float maxSpawnTime; //max time to wait until spawning the next enemy
    public GameObject model; //the enemy to copy for each wave

    public void resetWave(int waveNumber) //changes the wave to this wave
=======
    public float spawnMin; //min time to wait until spawning next enemy
    public float spawnMax; //max time to wait until spawning the next enemy
	public GameObject enemyPrefab;
	public GameObject player;
	public Sprite[] anxiousSprites;
	public Sprite[] characterSprites;
	public char[] buttons;
	GameObject lastEnemy;
	float lastSpawnTime;
	float waitTime; //Actual wait time between spawning enemies between min and max above.
	Vector3 spawnPoint;
	char button;
	int buttonIndex;

    struct EnemyData 
	{
      int speed;
      string button;
    }
		

	void Start()
	{
		waitTime = Random.Range (spawnMin, spawnMax);
	}


	void Update()
	{
		if (Time.time > lastSpawnTime + waitTime) 
		{
			if (enemiesLeft >= 1) 
			{
				spawnEnemy ();
				lastSpawnTime = Time.time;
				waitTime = Random.Range (spawnMin, spawnMax);
			}
		}
	}


/*    EnemyWaveScript(int waveNumber)
>>>>>>> master
    {
        //assign variables
        this.waveNumber = waveNumber;

        //calculate data based on wave
        enemiesLeft = (int)Mathf.Sqrt(40 * waveNumber) + Random.Range(2, 8) + 15; //y = .5x + 10
        //TODO calculate max and min spawn time

        EnemyScript modelScript = (EnemyScript)model.GetComponent(typeof(EnemyScript)); //get the script of the enemy
        modelScript.speed = Mathf.Sqrt(50 * waveNumber) + 5; //y = sqrt{50x}+5
    }
*/


    public GameObject spawnEnemy(char key)
    {
<<<<<<< HEAD
        print("Called");
        if (enemiesLeft > 1) { //if there are still enemies left in this wave
            enemiesLeft--;

            //clone the enemy and edit its button property and then return the button
            GameObject clone = (GameObject)Instantiate(model);
            EnemyScript cloneScript = (EnemyScript)clone.GetComponent(typeof(EnemyScript));
            cloneScript.button = key;

            return clone; //return the enemy
        }
        return null; //TODO return a  copy of the enemy
    }
=======
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

>>>>>>> master


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