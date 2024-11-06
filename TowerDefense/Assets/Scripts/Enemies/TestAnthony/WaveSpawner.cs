using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;
    private float spawnDelay = 0.5f;

    private int waveIndex = 1;
    
    
    void Update()
    {
        if (countdown <= 0)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves; //reset countdown
        }

        countdown -= Time.deltaTime; //reduce time by 1 per sec

    }

    IEnumerator SpawnWave ()
    {
        Debug.Log("Wave Incomming!");

        waveIndex++;
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnDelay);
        }
        
    }
    void SpawnEnemy()
    {
        Instantiate(enemyPrefab,spawnPoint.position, spawnPoint.rotation);
    }

}
