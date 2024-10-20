using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Se mueve mientras dispara en tiempos aleatorios
//Podría haber sido solo 1 script junto a Generator02Behaviour

public class Generator01Behaviour : MonoBehaviour
{
    //Le asignamos el objeto que generará
    [SerializeField]
    private GameObject plataformaDesplazable;
    //Tiempo en que sale la primera plataforma
    [SerializeField]
    private float tiempoInicial;
    //Intervalo en que sale la siguiente plataforma
    [SerializeField]
    private float intervalo;

    void Start()
    {
        //InvokeRepeating que llama al metodo GenerarPlataforma
        InvokeRepeating("GenerarPlataforma", tiempoInicial, intervalo);
    }
    //Metodo que genera las plataformas
    public void GenerarPlataforma()
    {
        Instantiate(plataformaDesplazable, transform.position, transform.rotation);
    }
}
