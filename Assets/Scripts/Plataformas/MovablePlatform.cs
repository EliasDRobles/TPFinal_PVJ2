using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
