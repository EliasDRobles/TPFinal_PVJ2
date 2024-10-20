using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaGiratoria : MonoBehaviour, IGiratorio
{
    [SerializeField] 
    private float velocidadRotacion = 50f;

    public void Girar()
    {
        transform.Rotate(0, velocidadRotacion * Time.deltaTime, 0);
    }
}
