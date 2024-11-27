using UnityEngine;

public class ProjectileCanion : MonoBehaviour
{
    public float speed = 20f;           // Velocidad del proyectil
    public float damage = 40f;         // Daño infligido
    public float explosionRadius = 3f; // Radio de explosión

    private void Start()
    {
        // Mover el proyectil hacia adelante
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Detectar colisión con un enemigo
        if (other.CompareTag("Enemy"))
        {
            Explode(); // Aplica daño en área
            Destroy(gameObject); // Destruye el proyectil
        }
    }

    private void Explode()
    {
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider enemyCollider in hitEnemies)
        {
            Enemy enemyScript = enemyCollider.GetComponent<Enemy>();
            if (enemyScript != null)
            {
                enemyScript.TakeDamage((int)damage); // Convierte el daño a entero
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Visualizar el radio de explosión en el editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
