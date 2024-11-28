using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0; 

    public Transform enemyPrefab;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;
    private float spawnDelay = 0.5f;

    public TextMeshProUGUI waveCountdownText;

    private int waveIndex = 1;
    
    
    void Update()
    {
        if (EnemiesAlive > 0)
        {
            return;
        }
        if (countdown <= 0)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves; //reset countdown
            return;
        }

        countdown -= Time.deltaTime; //reduce time by 1 per sec

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownText.text = string.Format("{0:00.00}", countdown);

    }

    IEnumerator SpawnWave ()
    {
        waveIndex++;
        for (int i = 0; i < waveIndex; i++)
        {
            int currentWave = i + 1;
            Debug.Log("WAVE: " + currentWave);
            SpawnEnemy();
            yield return new WaitForSeconds(spawnDelay);
        }
        
    }
    void SpawnEnemy()
    {
        if (enemyPrefab != null)
        {
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            EnemiesAlive++;
        }
        else
        {
            Debug.LogWarning("Enemy prefab is missing!");
        }
    }

}
