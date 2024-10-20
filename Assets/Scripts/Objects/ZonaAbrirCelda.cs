using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaAbrirCelda : MonoBehaviour
{
    [SerializeField]
    private GameObject celdaObjetivo;

    private void OnTriggerEnter(Collider other)
    {
        //Obtenemos el GameObject DoorSystem
        PuertaCelda celda = celdaObjetivo.GetComponent<PuertaCelda>();
        //Si el premio colisiona con el boton mientras la puerta esta cerrada
        if (other.CompareTag("Player") && (celda.Cerrado))
        {
            //Se abre la puerta
            celda.AbrirCelda();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Obtenemos el GameObject DoorSystem
        PuertaCelda celda = celdaObjetivo.GetComponent<PuertaCelda>();
        //Si el premio colisiona con el boton mientras la puerta esta cerrada
        if (other.CompareTag("Player") && (!celda.Cerrado))
        {
            //Se abre la puerta
            celda.CerrarCelda();
        }
    }
}
