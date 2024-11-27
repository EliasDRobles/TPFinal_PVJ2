using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPool : MonoBehaviour
{
    public GameObject platformPrefab; 
    public int poolSize = 5;         

    private Queue<GameObject> pool = new Queue<GameObject>();

    private void Start()
    {
        
        for (int i = 0; i < poolSize; i++)
        {
            GameObject platform = Instantiate(platformPrefab);
            platform.SetActive(false); 
            pool.Enqueue(platform);
        }
    }

  
    public GameObject GetPlatform()
    {
        if (pool.Count > 0)
        {
            GameObject platform = pool.Dequeue();
            platform.SetActive(true); 
            return platform;
        }
        else
        {
            
            GameObject newPlatform = Instantiate(platformPrefab);
            newPlatform.SetActive(true);
            return newPlatform;
        }
    }

    // Método para devolver una plataforma al pool
    public void ReturnPlatform(GameObject platform)
    {
        platform.SetActive(false); 
        pool.Enqueue(platform);
    }
}