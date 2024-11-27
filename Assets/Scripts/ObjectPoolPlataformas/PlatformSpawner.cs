using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public PlatformPool platformPool; 
    public float spawnDistance = 10f; 
    public int initialPlatforms = 5; 
    public Vector3 startSpawnPosition = Vector3.zero; 
    private Vector3 nextSpawnPosition;
    private Vector3 returnPosition = new Vector3(-10, 0, 32); 

    private void Start()
    {
        
        nextSpawnPosition = startSpawnPosition;

        for (int i = 0; i < initialPlatforms; i++)
        {
            SpawnPlatform();
        }
    }

    public void SpawnPlatform()
    {
        
        GameObject platform = platformPool.GetPlatform();

        
        platform.transform.position = nextSpawnPosition;

       
        nextSpawnPosition += new Vector3(0, 0, 0);
    }

    public void ReturnPlatform(GameObject platform)
    {
        
        platform.transform.position = returnPosition;

        
        platformPool.ReturnPlatform(platform);

       
        SpawnPlatform();
    }
}