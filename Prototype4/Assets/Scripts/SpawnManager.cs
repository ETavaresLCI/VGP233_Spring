using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    
    private float spawnRange = 5.0f;
    private int enemyCount;
    private int waveNumber = 1;


    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        float spawnPosY = 2.5f;
        return new Vector3(spawnPosX, spawnPosY, spawnPosZ);
    }

    void SpawnEnemyWave(int numberOfEnemies)
    {
        for(int i = 0; i < numberOfEnemies; ++i)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if(enemyCount == 0)
        {
            SpawnEnemyWave(++waveNumber);
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        }
    }
}
