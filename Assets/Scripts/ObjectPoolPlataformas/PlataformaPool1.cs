using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaPool1 : MonoBehaviour
{
    public float speed = 5f; 
    public float maxDistance = 100f; 

    private Vector3 initialPosition; 
    private PlatformSpawner spawner; 

    private void Start()
    {
        initialPosition = transform.position; 
        spawner = FindObjectOfType<PlatformSpawner>(); 
    }

    private void Update()
    {
        
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        
        float distanceTraveled = Vector3.Distance(initialPosition, transform.position);

        
        if (distanceTraveled >= maxDistance)
        {
            ReturnToPool();
        }
    }

    private void ReturnToPool()
    {
        
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        
        if (spawner != null)
        {
            spawner.ReturnPlatform(gameObject);
        }
    }
}