using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonCrearObjeto : MonoBehaviour
{
    [SerializeField] private ObjectPool objectPool;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            objectPool.ObtenerObjeto();
        }
    }
}
