using UnityEngine;
using System.Collections;

public class EnemyWaveScript : MonoBehaviour {

    public int waveNumber; //the wave number
    public int enemiesLeft; //number of enemies currently left in the wave
    public float minSpawnTime; //min time to wait until spawning next enemy
    public float maxSpawnTime; //max time to wait until spawning the next enemy
    public GameObject model; //the enemy to copy for each wave

    public void resetWave(int waveNumber) //changes the wave to this wave
    {
        //assign variables
        this.waveNumber = waveNumber;

        //calculate data based on wave
        enemiesLeft = (int)Mathf.Sqrt(40 * waveNumber) + Random.Range(2, 8) + 15; //y = .5x + 10
        //TODO calculate max and min spawn time

        EnemyScript modelScript = (EnemyScript)model.GetComponent(typeof(EnemyScript)); //get the script of the enemy
        modelScript.speed = Mathf.Sqrt(50 * waveNumber) + 5; //y = sqrt{50x}+5
    }

    public GameObject spawnEnemy(char key)
    {
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

}
