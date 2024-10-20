using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boton : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //Obtenemos el GameObject DoorSystem
        PuertaCelda celda = GameObject.Find("Celda").GetComponent<PuertaCelda>();
        //Si el premio colisiona con el boton mientras la puerta esta cerrada
        if (other.CompareTag("Objeto") && (celda.Cerrado))
        {
            //Se abre la puerta
            celda.AbrirCelda();
        }
    }
}
