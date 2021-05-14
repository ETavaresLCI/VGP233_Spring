using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnPosZ = 20.0f;
    private float xRange = 19.0f;

    private float startDelay = 2.0f;
    private float spawnInterval = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    private void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, 3);
        Vector3 spawnPos = new Vector3(Random.Range(-xRange, xRange), 0.0f, spawnPosZ);
        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }
}
