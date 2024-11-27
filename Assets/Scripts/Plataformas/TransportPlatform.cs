using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportPlatform : MonoBehaviour
{
    [SerializeField]
    private bool transportaPersonaje;

    private void OnCollisionStay(Collision collision)
    {
        if (transportaPersonaje && collision.collider.CompareTag("Player"))
        {
            collision.collider.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (transportaPersonaje && collision.collider.CompareTag("Player"))
        {
            collision.collider.transform.SetParent(null);
        }
    }
}
