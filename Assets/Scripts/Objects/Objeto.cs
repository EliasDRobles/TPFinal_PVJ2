using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objeto : MonoBehaviour
{
    private float giro = 50f;
    [SerializeField]
    private bool estaGirando;
    public bool EstaGirando { get => estaGirando; set => estaGirando = value; }
    private void Start()
    {
        estaGirando = true;
    }
    void Update()
    {
        if (estaGirando)
        {
            transform.Rotate(0, giro * Time.deltaTime, 0);
        }
        else
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
    }
}
