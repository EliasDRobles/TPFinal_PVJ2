using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Muestra la barra de vida en la pantalla
public class BarraDeVida : MonoBehaviour
{
    //Le asignamos el objeto que se mostrará
    public GameObject BarraVida;
    //Creamos un GameObject estatico
    public static GameObject BarraVidaStatic;

    void Start()
    {
        //Hacemos que el GameObject estatico sea igual a la barra de vida
        BarraVidaStatic = BarraVida;
        //La barra de vida quedara siempre visible
        BarraVidaStatic.SetActive(true);
    }
}
