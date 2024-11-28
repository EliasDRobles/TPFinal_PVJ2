using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Plataforma que se solo se mueve
//Utiliza una interfaz
//Hereda de plataforma
public class MovablePlatform : Platform, IMovable
{
    [SerializeField]
    private float speed = 2f;

    public override void PerformAction()
    {
        Move();
    }

    public void Move()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }
}
