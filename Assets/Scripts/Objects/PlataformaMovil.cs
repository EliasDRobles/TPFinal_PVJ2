using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovil : MonoBehaviour, IMovible
{
    [SerializeField] 
    private float velocidad = 2f;

    public void Mover()
    {
        transform.Translate(velocidad * Time.deltaTime, 0, 0);
    }
}
