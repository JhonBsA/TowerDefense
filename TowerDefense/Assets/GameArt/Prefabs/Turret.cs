using UnityEngine;

public class Turret : MonoBehaviour
{
    public float detectionRange = 10f;
    public float fireRate = 1f;
    public GameObject projectilePrefab;
    public Transform firePoint;
    public Transform rotatingPart;

    private Transform target;
    private float fireCountdown = 0f;

    void Update()
    {
        FindTarget();

        if (target != null)
        {
            // Rotate the weapon-ballista towards the target
            Vector3 direction = target.position - rotatingPart.position;
            direction.y = 0; // Keeps rotation level
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            rotatingPart.rotation = Quaternion.Lerp(rotatingPart.rotation, lookRotation, Time.deltaTime * 5f);

            // Fire if ready
             if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = fireRate;
            }

            fireCountdown -= Time.deltaTime;
        }
    }

    void FindTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < shortestDistance && distance <= detectionRange)
            {
                shortestDistance = distance;
                nearestEnemy = enemy;
            }
        }

        target = nearestEnemy != null ? nearestEnemy.transform : null;
    }

    void Shoot()
    {
        GameObject projectileGO = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Projectile projectile = projectileGO.GetComponent<Projectile>();

        if (projectile != null)
        {
            projectile.Seek(target);
        }
    }
}
