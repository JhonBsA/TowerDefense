using System.Collections;
using UnityEngine;

public class ProjectileArrow : ProjectileManager
{
    public float damage = 25f;

    protected override void HitTarget()
    {
        Debug.Log("Hit arrow");

        EnemyBase enemyBase = target.GetComponent<EnemyBase>();
        if (enemyBase != null)
        {
            enemyBase.TakeDamage(damage);
            Debug.Log($"Enemy hit for {damage} damage!");
        }
        else
        {
            Debug.Log($"Enemy hit for {damage} damage!");
        }

        base.HitTarget(); // Llama al comportamiento básico
    }
}
