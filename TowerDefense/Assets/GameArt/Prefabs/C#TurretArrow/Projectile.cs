using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 20f;
    private Transform target;

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
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

    void HitTarget()
    {
        Destroy(gameObject); // Destruir el proyectil
        // Aqu� podr�as a�adir l�gica para aplicar da�o al enemigo
    }
}
