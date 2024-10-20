using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformCoroutine : MonoBehaviour
{
    [SerializeField]
    private GameObject plataforma; //Hace referencia al objeto que se moverá con corrutina, en este caso la plataforma
    [SerializeField]
    private Transform[] puntosControl; //Un arraylist que contiene las posiciones de los puntos de control (puntos donde irá el objeto)
    [SerializeField]
    private float velocidad = 2f; //Se le asigna una velocidad de movimiento a la plataforma

    void Start()
    {
        StartCoroutine("MuevePlataforma"); //Iniciamos la corrutina
    }

    IEnumerator MuevePlataforma() //Intanciamos la corrutina
    {
        int i = 0; //Se declara la variable i, siendo esta el índice del array
        Vector3 nuevaPosicion = new Vector3(puntosControl[i].position.x, plataforma.transform.position.y, puntosControl[i].position.z); //Se crea un Vector3 que toma la posición del punto de control
        while (true) //Este while nos permite crear un bucle infinito, por lo que la plataforma nunca dejará de moverse entre los puntos de control
        {
            while (plataforma.transform.position != nuevaPosicion) //Mientras la posición de la plataforma sea distinta a la nueva posición
            {
                plataforma.transform.position = Vector3.MoveTowards(plataforma.transform.position, nuevaPosicion, velocidad * Time.deltaTime); //Le asignamos la nueva posición y la velocidad a través del método MoveTowards ()
                yield return null; //Las corrutinas siempre deben retornar algo, en este caso retornaremos un null
            }
            yield return new WaitForSecondsRealtime(1f); //Cuando llegue a la posición que se le asignó, esperamos 1 segundo
            if (i < 3) //Si el índice es menor que 3, entonces
            {
                i++; //Aumentamos el número del índice
            }
            else //Sino
            {
                i = 0; //Le asignamos el número 0
            }
            nuevaPosicion = new Vector3(puntosControl[i].position.x, plataforma.transform.position.y, puntosControl[i].position.z); //Volvemos a asignar un nuevo Vector3 a nuevaPosicion (esto hará que podamos regresar al lugar de inicio)
        }
    }
}
