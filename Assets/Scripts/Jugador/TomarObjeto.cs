using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomarObjeto : MonoBehaviour
{
    [SerializeField] private GameObject point;

    private GameObject objetoAgarrado = null; // para saber si tenemos un objeto o no en la mano 

    void Update()
    {
        if (objetoAgarrado != null)
        {

            if (Input.GetKey("r"))
            {

                objetoAgarrado.GetComponent<Rigidbody>().useGravity = true;

                objetoAgarrado.GetComponent<Rigidbody>().isKinematic = false;

                objetoAgarrado.gameObject.transform.SetParent(null);

                Objeto objeto = objetoAgarrado.GetComponent<Objeto>();

                objeto.EstaGirando = true;

                objetoAgarrado = null;
            }
        }


    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Objeto"))  // comparamos el tag del objecto
        {
            if (Input.GetKey("e") && objetoAgarrado == null)  //al apretar la tecla "E" podemos agarrar el objeto mientras que no tengamos nada en la mano 
            {
                other.GetComponent<Rigidbody>().useGravity = false;

                other.GetComponent<Rigidbody>().isKinematic = true;



                other.transform.position = point.transform.position;

                other.gameObject.transform.SetParent(point.gameObject.transform);

                objetoAgarrado = other.gameObject;

                Objeto objeto = objetoAgarrado.GetComponent<Objeto>();

                objeto.EstaGirando = false;

            }
        }
    }
}
