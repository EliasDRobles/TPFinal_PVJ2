using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //Obtenemos el GameObject DoorSystem
        DoorSystem door = GameObject.Find("DoorSystem").GetComponent<DoorSystem>();
        //Si el premio colisiona con el boton mientras la puerta esta cerrada
        if (other.CompareTag("Premio") && (door.Closed))
        {
            //Se abre la puerta
            door.OpenDoor();
        }
    }
}
