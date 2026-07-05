using System.Collections.Generic;
using UnityEngine;

public class LevelGenrator : MonoBehaviour
{

    //Public Variable Diclaration

    public GameObject chunkPrefab;
    public int StartingChunkAmount = 10;
    public Transform chunkParent;

    public float chunkLength = 10f;
    public float chunkMoveSpeed  =  8f;
    
    //public GameObject[] chunks = new GameObject[12];
    List<GameObject> chunks = new List<GameObject>();

    //Privates





    void Start()
    {
        SpawnStartingChunks();

    }

    private void SpawnStartingChunks()
    {
        for (int i = 0; i < StartingChunkAmount; i++) //never complete
        {
            SpawnChunk();
        }
    }

    private void SpawnChunk()
    {
        float spawnPositionZ = calculateSpawnPositionZ();
        Vector3 chunkSpawnPos = new Vector3(transform.position.x, transform.position.y, spawnPositionZ);
        GameObject newChunk = Instantiate(chunkPrefab, chunkSpawnPos, Quaternion.identity, chunkParent);

        chunks.Add(newChunk);
    }

    private float calculateSpawnPositionZ()
    {
        float spawnPositionZ;

        if (chunks.Count == 0)
        {
            spawnPositionZ = transform.position.z;
        }
        else
        {
            spawnPositionZ = chunks[chunks.Count - 1].transform.position.z + chunkLength;
        }

        return spawnPositionZ;
    }


    void FixedUpdate()
    {
        MoveChunkMethod();
    }


    void MoveChunkMethod()
    {
        for (int i = 0; i < chunks.Count; i++)
        {
            GameObject chunk = chunks[i];
            chunk.transform.Translate(-transform.forward * (chunkMoveSpeed * Time.deltaTime));
            if(chunk.transform.position.z <= Camera.main.transform.position.z - chunkLength)
            {
                chunks.Remove(chunk);
                Destroy(chunk);
                SpawnChunk();
            } 
        }

        
    }
}
