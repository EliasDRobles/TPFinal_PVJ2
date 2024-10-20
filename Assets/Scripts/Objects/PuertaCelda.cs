using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PuertaCelda : MonoBehaviour
{
    [SerializeField]
    private float posicionDestino;
    [SerializeField]
    private float posicionInicial;
    [SerializeField]
    private int tiempo;
    //Booleano que dictamina si esta cerrada o abierta
    private bool cerrado;
    //Metodos accesores para closed
    public bool Cerrado { get => cerrado; set => cerrado = value; }

    void Start()
    {
        posicionInicial = transform.position.x;
        cerrado = true;
    }
    //Metodo OpenDoor (Abrir la puerta)
    public void AbrirCelda()
    {
        if (cerrado)
        {
            transform.DOMoveX(posicionDestino, tiempo).SetEase(Ease.InCubic);
            cerrado = false;
        }
    }

    public void CerrarCelda()
    {
        transform.DOMoveX(posicionInicial, tiempo).SetEase(Ease.InCubic);
        cerrado = true;
    }
}
