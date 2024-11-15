using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObserver 
{
    void ActualizarCheckpoint(Vector3 nuevaPosicion, int playerID);
}
