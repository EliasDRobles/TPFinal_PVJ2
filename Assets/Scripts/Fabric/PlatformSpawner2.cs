using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlatformSpawner2 : MonoBehaviour
{
    public PlatformFactory platformFactory; // Referencia a la f�brica
    public float spawnInterval = 2f; // Intervalo entre plataformas
    public Vector3 initialSpawnPosition; // Posici�n inicial para las plataformas
    public float spawnOffset = 10f; // Distancia entre plataformas
    public float platformSpeed = 5f; // Velocidad de las plataformas
    public float platformMaxDistance = 100f; // Distancia m�xima de las plataformas

    private Vector3 nextSpawnPosition2; // Posici�n para la pr�xima plataforma

    private void Start()
    {
        // Configura la posici�n inicial de spawn
        nextSpawnPosition2 = initialSpawnPosition;

        // Inicia el ciclo de generaci�n
        InvokeRepeating(nameof(SpawnPlatform), 0f, spawnInterval);
    }

    private void SpawnPlatform()
    {
        // Usa la f�brica para crear una plataforma
        platformFactory.CreatePlatform(nextSpawnPosition2, platformSpeed, platformMaxDistance);

        // Actualiza la posici�n de spawn para la pr�xima plataforma
        nextSpawnPosition2 += new Vector3(spawnOffset, 0, 0);
    }
}