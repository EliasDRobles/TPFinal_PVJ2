using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaTransportadora : MonoBehaviour
{
    [SerializeField] 
    private bool transportaPersonaje;

    private void OnCollisionStay(Collision collision)
    {
        if (transportaPersonaje)
        {
            collision.collider.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (transportaPersonaje)
        {
            collision.collider.transform.SetParent(null);
        }
    }
}
