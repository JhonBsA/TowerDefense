using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public float velocidad = 20f;
    public int da�o = 10;
    private Transform objetivo;

    public void Buscar(Transform _objetivo)
    {
        objetivo = _objetivo;
    }

    void Update()
    {
        if (objetivo == null)
        {
            Destroy(gameObject); // Destruye la flecha si no hay objetivo
            return;
        }

        Vector3 direccion = objetivo.position - transform.position;
        float distanciaEstaFrame = velocidad * Time.deltaTime;

        // Apunta la flecha en direcci�n al objetivo
        transform.LookAt(objetivo);

        // Si la flecha ha alcanzado el objetivo, aplica da�o
        if (direccion.magnitude <= distanciaEstaFrame)
        {
            ImpactarObjetivo();
            return;
        }

        // Mueve la flecha hacia el objetivo
        transform.Translate(Vector3.forward * distanciaEstaFrame);
    }

    void ImpactarObjetivo()
    {
        // Aplica da�o al enemigo
        Enemigo enemigo = objetivo.GetComponent<Enemigo>();
        if (enemigo != null)
        {
            enemigo.RecibirDa�o(da�o);
        }

        Destroy(gameObject); // Destruye la flecha despu�s de impactar
    }
}
