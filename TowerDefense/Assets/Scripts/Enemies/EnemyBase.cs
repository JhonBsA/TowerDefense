using UnityEngine;
using UnityEngine.UI;

public class EnemyBase : MonoBehaviour
{
    [HideInInspector]
    
    public int startHealth = 100;
    public float health;

    public int value = 5;

    public GameObject deathEffect;

    [Header("Unity Stuff")]
    public Image healthBar;

    void Start()
    {
        health = startHealth;
    }
    public void TakeDamage(float amount)
    {
        health -= amount;

        if (healthBar != null)
        {
            healthBar.fillAmount = health / startHealth;
        }
        else
        {
            Debug.LogWarning("Health bar is not assigned!");
        }


        //Death
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1f);


        PlayerStats.Money += value;
        Destroy(gameObject); // Destroys the enemy when health reaches 0
        WaveSpawner.EnemiesAlive--;
    
    }

}