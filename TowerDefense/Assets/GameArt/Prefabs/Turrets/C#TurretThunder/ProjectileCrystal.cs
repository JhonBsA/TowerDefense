using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 20f;

    public int damage = 50;
    private Transform target;
    public GameObject impactEffect;

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    protected virtual void HitTarget()
    {
        Debug.Log("Successfull enemy hit!");
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2f);
        Destroy(gameObject); // Destruir el proyectil
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject); // Destruye el proyectil si no tiene objetivo
            return;
        }

        Vector3 direction = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (direction.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }



    void Damage(Transform enemy)
    {
        EnemyBase e = enemy.GetComponent<EnemyBase>();

        if ( e != null)
        {
            e.TakeDamage(damage);
            Debug.Log("Enemy has taken damage");

        }
        else
        {
            Debug.Log("Enemy has no EnemyBase Script");
        }
    }
}
