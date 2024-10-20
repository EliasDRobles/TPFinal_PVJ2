using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Vida
{
    public float MaxVida { get; private set; }
    public float ActualVida { get; private set; }
    private Image sistemaVida;

    public Vida(float maxVida, Image sistemaVida)
    {
        MaxVida = maxVida;
        ActualVida = MaxVida;
        this.sistemaVida = sistemaVida;
    }

    public void TomarDaño(float cantidad)
    {
        ActualVida -= cantidad;
        Debug.Log(ActualVida);
        ActualizarVida();
    }

    private void ActualizarVida()
    {
        sistemaVida.fillAmount = ActualVida / MaxVida;
    }

    public bool EstaMuerto()
    {
        return ActualVida <= 0;
    }
}
