using System;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;
    private EnemyBase targetEnemy;

    [Header("General")]
    public float detectionRange = 3f;

    [Header("Projectile Turret (default)")]
    public float fireRate = 1f;
    public GameObject projectilePrefab;
    public Transform firePoint;
    public Transform rotatingPart;
    private float fireCountdown = 0f;
    public Color gizmoColor = Color.white;

    [Header("Laser Turret")]
    public bool useLaser = false;

    public int damageOverTime = 30;
    public float slowAmount = .5f;

    public LineRenderer lineRenderer;
    public ParticleSystem impactEffect;
    public Light impactLight;

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
        else
        {
            // Disable the laser when there is no target
            if (useLaser && lineRenderer.enabled)
            {
                lineRenderer.enabled = false;
                impactEffect.Stop();
                impactLight.enabled = false;
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
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= detectionRange)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<EnemyBase>();
        }
        else
        {
            target = null;
        }
        

    }
    void Laser()
    {
        #region Logic
        if (target == null)
        {
            Debug.LogWarning("[Turret] Target is null in Laser method!");
            return;
        }
        else if(targetEnemy == null)
        {
            Debug.LogWarning("[Turret] TargetEnemy  is null in Laser method!");
            return;
        }

        else
        {
            targetEnemy.TakeDamage(damageOverTime * Time.deltaTime);
            targetEnemy.Slow(slowAmount);
        }
        #endregion

        #region Visuals
        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            impactEffect.Play();
            impactLight.enabled = true;

        }

        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);

        Vector3 dir = firePoint.position - target.position;


        impactEffect.transform.position = target.position + dir.normalized * 0.25f;

        impactEffect.transform.rotation = Quaternion.LookRotation(dir);
        #endregion

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

    void OnDrawGizmosSelected()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
