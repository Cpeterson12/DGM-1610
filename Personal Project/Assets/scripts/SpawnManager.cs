using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefab;

     private float spawnRangeX = 10;
    private float spawnYMin = 1; // set min spawn 
    private float spawnYMax = 7; // set max spawn 

    // Start is called before the first frame update
    void Start()
    {
        
    }

   Vector3 GenerateSpawnPosition ()
    {
        float xPos = Random.Range(-spawnRangeX, spawnRangeX);
        float yPos = Random.Range(spawnYMin, spawnYMax);
        return new Vector3(xPos, 0, yPos);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
