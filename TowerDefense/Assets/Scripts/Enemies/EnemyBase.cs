using UnityEngine;
using UnityEngine.UI;

public class EnemyBase : MonoBehaviour
{
    [Header("Enemy Stats")]
    public int value = 5;
    public int startHealth = 100;
    public float startSpeed = 1f;

    [HideInInspector]
    public float health;
    [HideInInspector]
    public float speed = 1f;

    public GameObject deathEffect;

    [Header("Unity Stuff")]
    public Image healthBar;

    void Start()
    {
        health = startHealth;
        speed = startSpeed;
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

    public void Slow (float pct)
    {
        speed = startSpeed * (1f - pct);
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