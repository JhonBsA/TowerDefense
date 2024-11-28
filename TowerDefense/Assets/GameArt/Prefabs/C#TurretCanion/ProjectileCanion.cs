using UnityEngine;
using System.Collections;

public class ProjectileCanion : Projectile
{
    public float damage = 40f;         // Da�o infligido
    public float explosionRadius = 3f; // Radio de explosi�n 

    protected override void HitTarget()
    {
        Debug.Log("Hit canon");
        Explode(); // Llama a la funci�n de explosi�n
        base.HitTarget(); // Llama al comportamiento b�sico
    }

    private void Explode() // Prueba de efecto
    {
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider enemyCollider in hitEnemies)
        {
            Enemy enemyScript = enemyCollider.GetComponent<Enemy>();
            if (enemyScript != null)
            {
                enemyScript.TakeDamage((int)damage); // Convierte el da�o a entero
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Visualizar el radio de explosi�n en el editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
    private void Damage(Transform enemy)
    {
        Debug.Log($"Damaged enemy: {enemy.name} for {damage} points");
        Destroy(enemy.gameObject);
    }
}
