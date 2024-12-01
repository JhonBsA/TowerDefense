using System;
using UnityEngine;

public class TurretCrystal : MonoBehaviour
{
    private Transform target;

    [Header ("General")]
    public float detectionRange = 10f;

    [Header("Use Arrows (default)")]
    public float fireRate = 1f;
    public GameObject projectilePrefab;
    public Transform firePoint;
    public Transform rotatingPart;
    private float fireCountdown = 0f;

    [Header("Use Laser")]
    public bool useLaser = false;
    public LineRenderer lineRenderer;



    [Header("Unity Setup Fields)")]
    public string enemyTag = "Enemy";


    void Update()
    {
        FindTarget();

        if (target != null)
        {
            RotateTowardsTarget();
            if (useLaser)
            {
                Laser();
            }
            else
            {
                if (fireCountdown <= 0f)
                {
                    Shoot();
                    fireCountdown = 1f / fireRate;
                }

                fireCountdown -= Time.deltaTime;
            }
            
        }
    }

    void FindTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
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
    void Laser() 
    {
        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(0, target.position);
    }
    void RotateTowardsTarget()
    {
        Vector3 direction = target.position - rotatingPart.position;
        direction.y = 0; // Mantener la rotación en el plano horizontal
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        rotatingPart.rotation = Quaternion.Lerp(rotatingPart.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void Shoot()
    {
        if (projectilePrefab == null)
        {
            Debug.LogError("[Turret] Projectile Prefab is not assigned!");
            return;
        }
        else if (firePoint == null)
        {
            Debug.LogError("[Turret] Fire Point is not assigned!");
            return;
        }

        GameObject projectileGO = (GameObject)Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        ProjectileManager projectile = projectileGO.GetComponent<ProjectileManager>();

        if (projectile != null)
        {
            projectile.SetTarget(target);
        }
    }
}
