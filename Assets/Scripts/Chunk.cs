using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    public GameObject fencePrefab;
    public float[] lanes = {-2.5f,0f,2.5f};

    void Start()
    {
        Spawnfence();
    }

    void Spawnfence()
    {
        List<int> availableLanes = new List<int> {0,1,2};
        int fencesToSpawn = Random.Range(0,lanes.Length);

        for(int i= 0 ; i< fencesToSpawn ; i++)
        {
            if(availableLanes.Count <= 0 ) break;

            
            int randomLaneIndex = Random.Range(0,availableLanes.Count);
            int selectedLane = availableLanes[randomLaneIndex];
            availableLanes.RemoveAt(randomLaneIndex);
            
            
            Vector3 spawnPosition = new Vector3(selectedLane, transform.position.y, transform.position.z);
            Instantiate(fencePrefab, spawnPosition, Quaternion.identity, this.transform);

        }


    } 

}
