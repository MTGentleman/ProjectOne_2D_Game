using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour {

    // Use this for initialization

    public GameObject EnemyDuck;
    float randX;
    Vector2 spawnLocation;
    public float spawnRate = 4f;
    float nextSpawn = 0.0f;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(-7f, 6.5f);
            spawnLocation = new Vector2(randX, transform.position.y);
            Instantiate(EnemyDuck, spawnLocation, Quaternion.identity);
        }

	}
}
