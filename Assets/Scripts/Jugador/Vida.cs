using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
public class Vida : MonoBehaviour
{    
    [SerializeField]
    private Image sistemaVida;
    private float maxVida=10;
    private float vidaActual;

    public void Start()
    {
            vidaActual = maxVida;
    }
    public void TomarDaño()
    {
        vidaActual -= 1;
        ActualizarVida();
    }

    private void ActualizarVida()
    {
        sistemaVida.fillAmount = vidaActual / maxVida;
    }

    public bool EstaMuerto()
    {
        return vidaActual <= 0;
    }
}
