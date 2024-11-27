using UnityEngine;
using UnityEngine.UI;

public class EnemyBase : MonoBehaviour
{
    [HideInInspector]
    public float speed;

    public int startHealth = 100;
    public int health;

    [Header("Unity Stuff")]
    public Image healthBar;

    void Start()
    {
        health = startHealth;
    }
    public void TakeDamage(int amount)
    {
        health -= amount;

        healthBar.fillAmount = health / startHealth;


        //Death
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject); 
    }

}