using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] public GameObject EnemyPrefab;
    [SerializeField] public Transform[] spawnPoints;
    public float timeBetweenSpawns;
    public float startingDelay;
    public float minSpawnTime;
    float nextSpawnTime;
   
    // Start is called before the first frame update
    void Start()
    {
        nextSpawnTime = startingDelay;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            Vector2 spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
            Instantiate(EnemyPrefab, spawnPoint, Quaternion.identity);
            nextSpawnTime = Time.time + timeBetweenSpawns;
            if(timeBetweenSpawns > minSpawnTime)
            {
                timeBetweenSpawns -= 0.05f;
            }
        }

    }

}
