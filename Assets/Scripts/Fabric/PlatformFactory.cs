using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFactory : PlatformFactoryBase
{
    public GameObject platformPrefab;
    // Método para crear una plataforma
    public override GameObject CreatePlatform(Vector3 position, float speed, float maxDistance)
    {
        // Instancia una nueva plataforma
        GameObject platform = Instantiate(platformPrefab, position, Quaternion.identity);
        // Configura las propiedades específicas de la plataforma
        MovingPlatform movingPlatform = platform.GetComponent<MovingPlatform>();
        if (movingPlatform != null)
        {
            movingPlatform.speed = speed;
            movingPlatform.maxDistance = maxDistance;
        }
        return platform;
    }
}
