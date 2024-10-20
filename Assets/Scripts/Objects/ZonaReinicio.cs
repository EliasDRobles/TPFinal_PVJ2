using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaReinicio : MonoBehaviour
{
    [SerializeField]
    private GameObject playerZoneReset;
    [SerializeField]
    private GameObject objectZoneReset;
    public float daño = 1.0f;    

    private void OnTriggerEnter(Collider other)
    {
        Jugador player = GameObject.Find("Jugador").GetComponent<Jugador>();
        Objeto objeto = GameObject.Find("Objeto").GetComponent<Objeto>();
        if (other.gameObject.CompareTag("Player"))
        {
            player.transform.position = playerZoneReset.transform.position;
        }


        if (other.gameObject.CompareTag("Objeto"))
        {
            objeto.transform.position = objectZoneReset.transform.position; ;
        }
    }
}
