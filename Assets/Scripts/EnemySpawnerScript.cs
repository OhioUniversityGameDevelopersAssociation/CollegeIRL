using UnityEngine;
using System.Collections;

public class EnemySpawnerScript : MonoBehaviour {

    public int maxObjects;
    public Sprite[] enemySprites;
    public GameObject[] ingameObjects;
    float time = 0;
    EnemyWaveScript waveScript;

    // Use this for initialization
    void Start () {
        waveScript = GetComponentInParent<EnemyWaveScript>();
        waveScript.resetWave(10);
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        print(time);
        if(time > 2)
        {
            waveScript.spawnEnemy('k'); //spawn enemy
            time = 0; //reset time
        }
	}
}
