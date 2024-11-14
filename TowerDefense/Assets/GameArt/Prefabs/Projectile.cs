using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 50;
    private Transform target;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    void Update()
    {
       

        Vector3 direction = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        transform.LookAt(target); // Ensures the arrow points towards the target

        // If projectile reaches the target, apply damage
        if (direction.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        // Moves the projectile toward the target
        transform.Translate(Vector3.forward * distanceThisFrame);
    }

    void HitTarget()
    {
        EnemyZombie enemy = target.GetComponent<EnemyZombie>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        Destroy(gameObject); // Destroys the projectile after hitting the target
    }
}
