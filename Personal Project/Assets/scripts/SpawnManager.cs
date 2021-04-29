using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefab;

    private float spawnRangeX = 10;
    private float spawnYMin = 1; // set min spawn 
    private float spawnYMax = 7; // set max spawn 
    
    public float startDelay = 2.0f;
    public float repeatRate = 2.0f;

    private Vector3 spawnPos = new Vector3(30, 48, -8);

    private PlayerController PCS;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle",startDelay,repeatRate);
        PCS = GameObject.Find("Player").GetComponent<PlayerController>();
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

      void SpawnObstacle()
    {
        if(PCS.isGameOver == false)
        {
           int enemyIndex = Random.Range(0,enemyPrefab.Length);

           Instantiate(enemyPrefab[enemyIndex], spawnPos, enemyPrefab[enemyIndex].transform.rotation);
           Debug.Log("Spawning");
           
        }
    }
}
