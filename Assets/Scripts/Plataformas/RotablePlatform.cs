using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotablePlatform : Platform, IRotable
{
    [SerializeField]
    private float speedRotation = 50f;

    public override void PerformAction()
    {
        MakeRotation();        
    }

    public void MakeRotation()
    {
        transform.Rotate(0, speedRotation * Time.deltaTime, 0);
    }
}
