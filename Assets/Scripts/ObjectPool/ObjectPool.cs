using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [Header("Configuración del Object Pool")]
    [SerializeField] private GameObject objetoPrefab;  // El tipo de objeto que vamos a manejar
    [SerializeField] private int cantidadInicial = 1;   // Cuántos objetos crear inicialmente

    private Queue<GameObject> pool = new Queue<GameObject>();  // Cola para gestionar los objetos

    void Start()
    {
        // Crear los objetos iniciales y agregarlos al pool
        for (int i = 0; i < cantidadInicial; i++)
        {
            GameObject obj = Instantiate(objetoPrefab);
            obj.transform.position = transform.position;
            obj.SetActive(false);  // Desactiva el objeto
            pool.Enqueue(obj);  // Agrega al pool
        }
    }

    // Método para obtener un objeto del pool
    public GameObject ObtenerObjeto()
    {
        if (pool.Count > 0)
        {
            GameObject obj = pool.Dequeue();  // Obtiene un objeto del pool
            obj.SetActive(true);  // Activa el objeto
            return obj;
        }
        else
        {
            // Si no hay objetos se crea uno
            GameObject obj = Instantiate(objetoPrefab);
            obj.SetActive(true);
            return obj;
        }
    }

    // Método para devolver un objeto al pool
    public void DevolverObjeto(GameObject obj)
    {
        obj.transform.position = transform.position;
        obj.SetActive(false);  // Desactiva el objeto
        pool.Enqueue(obj);  // Devuelve el objeto al pool
    }
}
