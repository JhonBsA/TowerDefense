using UnityEngine;
using System.Collections;

public class ProjectileCanion : Projectile
{
    public float damage = 40f;         // Daño infligido
    public float explosionRadius = 3f; // Radio de explosión 

    protected override void HitTarget()
    {
        Debug.Log("Hit canon");
        Explode(); // Llama a la función de explosión
        base.HitTarget(); // Llama al comportamiento básico
    }

    private void Explode() // Prueba de efecto
    {
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider enemyCollider in hitEnemies)
        {
            Enemy enemyScript = enemyCollider.GetComponent<Enemy>();
            if (enemyScript != null)
            {
                enemyScript.TakeDamage((int)damage); // Convierte el daño a entero
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Visualizar el radio de explosión en el editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
    private void Damage(Transform enemy)
    {
        Debug.Log($"Damaged enemy: {enemy.name} for {damage} points");
        Destroy(enemy.gameObject);
    }
}
