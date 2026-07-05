using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsyacleSpawner : MonoBehaviour
{
    
    public Transform obstacleParent;
    public float obstacleSpawnTime =1f;
    public List<GameObject> obstaclesToSpawn = new List<GameObject>();
    float spawnWidth = 4f;

    void Start()
    {
       
        StartCoroutine(SpawnObstacleRoutine());
    
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    IEnumerator SpawnObstacleRoutine()
    {
        while (true)
        {
            Vector3 spawnPosion = new Vector3(Random.Range(-spawnWidth,spawnWidth),transform.position.y,transform.position.z);
            yield return new WaitForSeconds(obstacleSpawnTime);
            Instantiate(obstaclesToSpawn[Random.Range(0, obstaclesToSpawn.Count)],spawnPosion , Random.rotation, obstacleParent);
        }
    }


    
}
