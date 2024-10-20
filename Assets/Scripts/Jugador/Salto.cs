using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salto
{
    private Rigidbody rb;
    private float fuerzaSalto;
    private bool enTierra;
    private LayerMask mask;

    public Salto(Rigidbody rb, float fuerzaSalto, LayerMask mask)
    {
        this.rb = rb;
        this.fuerzaSalto = fuerzaSalto;
        this.mask = mask;
    }

    public bool EstaEnTierra(Transform transform)
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 0.6f, mask))
        {
            enTierra = true;
        }
        else
        {
            enTierra = false;
        }
        return enTierra;
    }

    public void Saltar()
    {
        if (enTierra)
        {
            rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
        }
    }
}

