using UnityEngine;
using System.Collections;

public class EnemyWaveScript : MonoBehaviour {

    public int waveNumber; //the wave number
    public int enemiesLeft; //number of enemies currently left in the wave
    public float spawnMin; //min time to wait until spawning next enemy
    public float spawnMax; //max time to wait until spawning the next enemy
    struct EnemyData {
      int speed;
      string button;
    }

    EnemyWaveScript(int waveNumber)
    {
        //assign variables
        this.waveNumber = waveNumber;

        //calculate data based on wave
        enemiesLeft = (int)Mathf.Sqrt(40 * waveNumber) + Random.Range(2, 8) + 15; //y = sqrt{40x} + 15 + (random)
        //TODO calculate other variables and define a default enemy
        //calc speed  y = sqrt{50x}+5
    }

    EnemyScript spawnEnemy()
    {
        if (enemiesLeft > 1)
        {
            enemiesLeft--;

            //TODO spawn enemy
        }
    }

}
