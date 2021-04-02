using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    
    private float spawnRange = 9;

    public int enemyCount;
    public int waveNumber =1;
    public GameObject powerupPrefab;

    // Start is called before the first frame update
    void Start()
    {
        // Spawn an Enemy
       SpawnEnemyWave(waveNumber);

       //Create Powerup for the player to collect
       Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
    }

    void update()
    {
        // Find how many enemies are in play
       enemyCount = FindObjectsOfType<enemy>().Length;
       //if enemy count gets down to zero, spawn in greater number
       if(enemyCount == 0)
       {
           waveNumber ++;
           SpawnEnemyWave(waveNumber);
         //Creates additional Powerups for the player to collect
         Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
       }
    }

  // method of Vector3 instead of void because it will return data
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        //returns value to function above
        return randomPos;
    }
   
   void SpawnEnemyWave(int enemiesToSpawn)
    {
       for(int i = 0; i < enemiesToSpawn; i++)
       {
          Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
       }
    }
}
