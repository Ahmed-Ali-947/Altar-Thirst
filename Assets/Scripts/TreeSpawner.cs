using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{
    public GameObject TreePrefab;
    public float timeBetweenSpawns;
    public Transform[] clampPoints;

    float nextSpawnTime;
    // Start is called before the first frame update
    void Start()
    {
        nextSpawnTime = timeBetweenSpawns;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextSpawnTime)
        {

            Vector2 randomPos = new Vector2(Random.Range(clampPoints[0].position.x, clampPoints[1].position.x), Random.Range(clampPoints[0].position.y, clampPoints[1].position.y));

            Instantiate(TreePrefab,randomPos,Quaternion.identity);
            nextSpawnTime = Time.time + timeBetweenSpawns;
        }
    }
}
