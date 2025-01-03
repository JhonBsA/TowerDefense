using UnityEngine;
using System.Collections;

public class ProjectileCanion : ProjectileManager
{
    public float damage = 40f;         // Da�o infligido
    public float explosionRadius = 0.5f; // Radio de explosi�n 

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
            EnemyBase enemyScript = enemyCollider.GetComponent<EnemyBase>();
            if (enemyScript != null)
            {
                enemyScript.TakeDamage((float)damage); // Convierte el da�o a entero
                Debug.Log($"Damaged enemy: {enemyCollider.name} for {damage} points");
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
