using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Village : MonoBehaviour
{
    public GameObject objToSpawn;
    public int totalSpawns;
    public float timeBetweenSpawns;

    public GameObject[] spawnPoints;

    float nextSpawnTime;
    int remainingSpawns;
    Vector2 randomSpawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        remainingSpawns = totalSpawns;
        nextSpawnTime = timeBetweenSpawns;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextSpawnTime)
        {
            randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
            Instantiate(objToSpawn, randomSpawnPoint, Quaternion.identity);
            remainingSpawns--;
            nextSpawnTime = Time.time + timeBetweenSpawns;
        }
        if (remainingSpawns < 0)
        {
            Destroy(gameObject);
        }
    }
}
