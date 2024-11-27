using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MovingPlatform : MonoBehaviour
{
    public float speed = 5f; // Velocidad de movimiento
    public float maxDistance = 100f; // Distancia máxima antes de destruir la plataforma

    private Vector3 initialPosition; // Posición inicial de la plataforma

    private void Start()
    {
        initialPosition = transform.position; // Guardar la posición inicial
    }

    private void Update()
    {
        // Mueve la plataforma hacia la izquierda
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        // Calcula la distancia recorrida
        float distanceTraveled = Vector3.Distance(initialPosition, transform.position);

        // Si la distancia supera el límite, destruye la plataforma
        if (distanceTraveled >= maxDistance)
        {
            Destroy(gameObject);
        }
    }
}