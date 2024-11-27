using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlatformSpawner2 : MonoBehaviour
{
    public PlatformFactory platformFactory; // Referencia a la fábrica
    public float spawnInterval = 2f; // Intervalo entre plataformas
    public Vector3 initialSpawnPosition; // Posición inicial para las plataformas
    public float spawnOffset = 10f; // Distancia entre plataformas
    public float platformSpeed = 5f; // Velocidad de las plataformas
    public float platformMaxDistance = 100f; // Distancia máxima de las plataformas

    private Vector3 nextSpawnPosition2; // Posición para la próxima plataforma

    private void Start()
    {
        // Configura la posición inicial de spawn
        nextSpawnPosition2 = initialSpawnPosition;

        // Inicia el ciclo de generación
        InvokeRepeating(nameof(SpawnPlatform), 0f, spawnInterval);
    }

    private void SpawnPlatform()
    {
        // Usa la fábrica para crear una plataforma
        platformFactory.CreatePlatform(nextSpawnPosition2, platformSpeed, platformMaxDistance);

        // Actualiza la posición de spawn para la próxima plataforma
        nextSpawnPosition2 += new Vector3(spawnOffset, 0, 0);
    }
}