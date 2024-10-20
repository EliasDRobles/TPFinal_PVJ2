using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    private IMovible movible;
    private IGiratorio giratorio;
    private PlataformaTransportadora transportadora;
    private PlataformaDisolvente disolvente;

    private void Start()
    {
        movible = GetComponent<IMovible>();
        giratorio = GetComponent<IGiratorio>();
        transportadora = GetComponent<PlataformaTransportadora>();
        disolvente = GetComponent<PlataformaDisolvente>();
    }

    private void Update()
    {
        movible?.Mover();
        giratorio?.Girar();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Destructor"))
        {
            Destroy(transform.gameObject);
        }
    }
}
