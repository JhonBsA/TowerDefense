using UnityEngine;

public class LightningTower : MonoBehaviour
{
    public float detectionRange = 4f;
    public GameObject lightningEffect; // The lightning effect prefab
    public Transform lightningTarget; // Reference to the LightningTarget object

    private Transform currentEnemyTarget;

    void Update()
    {
        FindTarget();

        if (currentEnemyTarget != null)
        {
            ActivateLightningEffect();
            UpdateLightningTarget(currentEnemyTarget);
        }
        else
        {
            DeactivateLightningEffect();
        }
    }

    void FindTarget()
    {
        Collider[] enemiesInRange = new Collider[10]; // Adjust the size based on expected max enemies
        int count = Physics.OverlapSphereNonAlloc(transform.position, detectionRange, enemiesInRange);
        float shortestDistance = Mathf.Infinity;
        Transform nearestEnemy = null;

        for (int i = 0; i < count; i++)
        {
            Collider collider = enemiesInRange[i];
            if (collider != null && collider.CompareTag("Enemy"))
            {
                float distance = Vector3.Distance(transform.position, collider.transform.position);
                if (distance < shortestDistance)
                {
                    shortestDistance = distance;
                    nearestEnemy = collider.transform;
                }
            }
        }

        currentEnemyTarget = nearestEnemy; // Assign the closest enemy as the target
    }



    void ActivateLightningEffect()
    {
        if (lightningEffect == null)
        {
            Debug.LogWarning("[LightningTower] Lightning effect is not assigned!");
            return;
        }

        if (!lightningEffect.activeSelf)
        {
            lightningEffect.SetActive(true);
        }
    }


    void DeactivateLightningEffect()
    {
        if (lightningEffect != null && lightningEffect.activeSelf)
        {
            lightningEffect.SetActive(false);
        }
    }

    void UpdateLightningTarget(Transform enemy)
    {
        FollowTarget followScript = lightningTarget.GetComponent<FollowTarget>();
        if (followScript != null)
        {
            followScript.SetTarget(enemy); // Update the FollowTarget script to follow the current enemy
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, detectionRange);

        if (currentEnemyTarget != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, currentEnemyTarget.position);
        }
    }

}
