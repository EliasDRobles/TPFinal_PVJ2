using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
public class Vida : MonoBehaviour
{    
    [SerializeField]
    private Image sistemaVida;
    private float maxVida=2;
    private float vidaActual; public float VidaActual { get => vidaActual; }

    public void Start()
    {
        vidaActual = maxVida;
        GameObject objetoImagen = GameObject.Find("BarraDeVida");
        sistemaVida = objetoImagen.GetComponent<Image>();
    }
    public void TomarDaño()
    {
        vidaActual -= 1;
        ActualizarVida();
        if (vidaActual > 0) return;
        
    }

    private void ActualizarVida()
    {
        sistemaVida.fillAmount = vidaActual / maxVida;
    }

    
}
