using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torreta : MonoBehaviour
{
    public float rangoDeDeteccion = 10f;
    public float tiempoEntreDisparos = 1f;
    public GameObject proyectilPrefab;
    public Transform puntoDeDisparo;
    public Transform weaponBallista; // Parte de la torreta que girará hacia el enemigo

    private Transform objetivo;
    private float tiempoDeDisparo = 0f;

    void Update()
    {
        // Buscar el objetivo más cercano en cada frame
        BuscarObjetivo();

        // Si tenemos un objetivo, giramos hacia él y disparamos
        if (objetivo != null)
        {
            // Rotar la ballesta hacia el objetivo
            Vector3 direccion = objetivo.position - weaponBallista.position;
            direccion.y = 0; // Evita rotaciones en el eje Y
            Quaternion rotacion = Quaternion.LookRotation(direccion);
            weaponBallista.rotation = Quaternion.Lerp(weaponBallista.rotation, rotacion, Time.deltaTime * 5f);

            // Disparar si el tiempo de recarga ha pasado
            if (tiempoDeDisparo <= 0f)
            {
                Disparar();
                tiempoDeDisparo = tiempoEntreDisparos;
            }

            tiempoDeDisparo -= Time.deltaTime;
        }
    }

    // Buscar el enemigo más cercano dentro del rango de detección
    void BuscarObjetivo()
    {
        GameObject[] enemigos = GameObject.FindGameObjectsWithTag("Enemigo");
        float distanciaMasCercana = Mathf.Infinity;
        GameObject enemigoMasCercano = null;

        foreach (GameObject enemigo in enemigos)
        {
            float distancia = Vector3.Distance(transform.position, enemigo.transform.position);
            if (distancia < distanciaMasCercana && distancia <= rangoDeDeteccion)
            {
                distanciaMasCercana = distancia;
                enemigoMasCercano = enemigo;
            }
        }

        // Asigna el objetivo si hay un enemigo dentro del rango, de lo contrario, el objetivo es nulo
        if (enemigoMasCercano != null)
        {
            objetivo = enemigoMasCercano.transform;
        }
        else
        {
            objetivo = null;
        }
    }

    void Disparar()
    {
        // Instancia el proyectil en el punto de disparo y lo dirige hacia el objetivo
        GameObject proyectilGO = Instantiate(proyectilPrefab, puntoDeDisparo.position, puntoDeDisparo.rotation);
        Proyectil proyectil = proyectilGO.GetComponent<Proyectil>();

        if (proyectil != null)
        {
            proyectil.Buscar(objetivo);
        }
    }
}
