using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour {

    // Use this for initialization

    public GameObject EnemyDuck1;
    public GameObject EnemyDuck2;
    public GameObject EnemyDuck3;
    float randX;
    Vector2 spawnLocation;
    public int spawnLimmit1 = 4;
    public int spawnLimmit2 = 5;
    public int spawnLimmit3 = 6;
    public int amountSpawned1 = 0;
    public int amountSpawned2 = 0;
    public int amountSpawned3 = 0;
    public int currentWave = 1;
    public float waveTime = 10;
    public float timePassed;
	void Start () {
        timePassed = 0;
    }
	
	// Update is called once per frame
	void Update () {

        timePassed += Time.deltaTime;     

		if ((currentWave == 1) && (timePassed <= waveTime))
        {
            if (amountSpawned1 < spawnLimmit1)
            {                
                randX = Random.Range(-7f, -18.5f);
                spawnLocation = new Vector2(randX, 9.0f);
                Instantiate(EnemyDuck1, spawnLocation, Quaternion.identity);
                amountSpawned1++;              
            }
            
        }

        if ((currentWave == 2) && (timePassed <= waveTime))
        {
            if (amountSpawned2 < spawnLimmit2)
            {                
                randX = Random.Range(7f, 19.5f);
                spawnLocation = new Vector2(randX, 9.0f);
                Instantiate(EnemyDuck2, spawnLocation, Quaternion.identity);
                amountSpawned2++;           
            }            
        }

        if ((currentWave == 3) && (timePassed <= waveTime))
        {
            if (amountSpawned3 < spawnLimmit3)
            {
                randX = Random.Range(-6f, 6f);
                spawnLocation = new Vector2(randX, 9.0f);
                Instantiate(EnemyDuck3, spawnLocation, Quaternion.identity);
                amountSpawned3++;
            }
        }

        if (timePassed >= waveTime)
        {
            currentWave++;
            timePassed = 0;
        }       

	}
}
