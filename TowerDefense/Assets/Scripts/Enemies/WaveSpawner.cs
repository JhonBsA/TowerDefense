using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public Wave[] waves;

    public static int EnemiesAlive = 0; 

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;
    private float spawnDelay = 0.5f;

    public TextMeshProUGUI waveCountdownText;

    private int waveIndex = 1;

    public LightTransitionManager lightTransitionManager;

    private void Start()
    {
        if (lightTransitionManager != null)
        {
            lightTransitionManager.StartLightTransition();
        }
    }

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
        Wave wave = waves[waveIndex];

        for (int i = 0; i < wave.count; i++)
        {
            int currentWave = i + 1;
            Debug.Log("WAVE: " + currentWave);
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }
        waveIndex++;

        if (waveIndex == waves.Length)
        {
            Debug.Log("LEVEL WON!");
            this.enabled = false;
        }


    }
    void SpawnEnemy(GameObject enemy)
    {
        {
            Instantiate(enemy.gameObject, spawnPoint.position, spawnPoint.rotation);
            EnemiesAlive++;
        }

    }

}
