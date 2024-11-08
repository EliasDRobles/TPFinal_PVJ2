using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Vida : MonoBehaviour
{    
    [SerializeField]
    private Image sistemaVida;
    [SerializeField]
    private float maxVida;
    [SerializeField]
    private float actualVida;
    public float MaxVida { get => maxVida; set => maxVida = value; }
    public float ActualVida { get => actualVida; set => actualVida = value; }

    public void TomarDaño()
    {
        ActualVida -= 1;
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
