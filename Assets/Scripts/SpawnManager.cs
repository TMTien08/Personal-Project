using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> enemys;
    public GameObject powerup;
    private float spawnEnemyPosZ = 12;
    private float spawnRangePowerupZ = 9;
    private float spawnRangeX = 16;
    private float spawnPosY = 0f;

    private float powerupSpawnTime = 5;
    private float enemySpawnTime = 1;
    private float timeDelay = 1;
    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), timeDelay, enemySpawnTime);
        InvokeRepeating(nameof(SpawnPowerup), timeDelay, powerupSpawnTime);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void SpawnEnemy()
    {
        float spawnPosX = Random.Range(-spawnRangeX, spawnRangeX);
        int indexEnemy = Random.Range(0, enemys.Count);
        Vector3 pos = new Vector3(spawnPosX, spawnPosY, spawnEnemyPosZ);
        Instantiate(enemys[indexEnemy], pos, enemys[indexEnemy].transform.rotation);
    }
    private void SpawnPowerup()
    {
        float spawnPosX = Random.Range(-spawnRangeX, spawnRangeX);
        float spawnPosZ = Random.Range(-spawnRangePowerupZ, spawnRangePowerupZ);

        Vector3 pos = new Vector3(spawnPosX, spawnPosY, spawnPosZ);
        Instantiate(powerup, pos, powerup.transform.rotation);
    }
}
