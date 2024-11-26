using UnityEngine;

public class TurretCannon : MonoBehaviour
{
    public float detectionRange = 10f; // Rango de detección
    public float fireRate = 1f; // Tasa de disparo
    public GameObject projectilePrefab; // Prefab del proyectil
    public Transform firePoint; // Punto de disparo
    public float projectileSpeed = 5f; // Velocidad del proyectil

    private float fireTimer = 0f;

    private void Update()
    {
        fireTimer += Time.deltaTime;

        if (fireTimer >= fireRate)
        {
            GameObject target = FindEnemyInRange();
            if (target != null)
            {
                Shoot(target);
                fireTimer = 0f;
            }
        }
    }

    GameObject FindEnemyInRange()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectionRange);
        foreach (Collider hit in hitColliders)
        {
            if (hit.CompareTag("Enemy"))
            {
                return hit.gameObject;
            }
        }
        return null;
    }

    void Shoot(GameObject target)
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();

        if (rb != null)
        {
            Vector3 direction = (target.transform.position - firePoint.position).normalized;
            rb.velocity = direction * projectileSpeed;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
