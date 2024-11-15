using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISubject 
{
    void AgregarObservador(IObserver observer);
    void RemoverObservador(IObserver observer);

    void Notificar(Vector3 nuevaPosicion, int playerID);
}
