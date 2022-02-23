using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerUpPrefabs;
    float randomSpawnPosX;
    float randomSpawnPosZ;
    public int enemyCount;
    public int waveNumber = 1;

    void Start()
    {
        SpawnEnemyWave(waveNumber);
        Instantiate(powerUpPrefabs, GenerateSpawnPoint(), powerUpPrefabs.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if(enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            Instantiate(powerUpPrefabs, GenerateSpawnPoint(), powerUpPrefabs.transform.rotation);
        }
    }

    void SpawnEnemyWave(int enemiesSpawn)
    {
        for (int i = 0; i < enemiesSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPoint(), enemyPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPoint()
    {
        randomSpawnPosX = Random.Range(-9, 9);
        randomSpawnPosZ = Random.Range(-9, 9);
        Vector3 randomSpawnPos = new Vector3(randomSpawnPosX, 0, randomSpawnPosZ);
        return randomSpawnPos;
    }
}
