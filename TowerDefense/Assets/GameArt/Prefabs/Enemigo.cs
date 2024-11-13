using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public int vida = 50;

    public void RecibirDaño(int cantidad)
    {
        vida -= cantidad;
        if (vida <= 0)
        {
            Morir();
        }
    }

    void Morir()
    {
        Destroy(gameObject); // Destruye el enemigo cuando su vida llega a 0
    }
}
