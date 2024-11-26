using UnityEngine;

public class ProjectileCanion : MonoBehaviour
{
    public float speed = 20f;           // Velocidad del proyectil
    public float damage = 40f;         // Da�o infligido
    public float explosionRadius = 3f; // Radio de explosi�n

    private void Start()
    {
        // Mover el proyectil hacia adelante
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Detectar colisi�n con un enemigo
        if (other.CompareTag("Enemy"))
        {
            Explode(); // Aplica da�o en �rea
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
                enemyScript.TakeDamage((int)damage); // Convierte el da�o a entero
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Visualizar el radio de explosi�n en el editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
