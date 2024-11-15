using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CambiarCheckpoint : MonoBehaviour, ISubject
{
    [SerializeField] private GameObject playerRespawn;
    private int playerID;
    private PhotonView photonView;

    private List<IObserver> observadores = new List<IObserver>();

    public void AgregarObservador(IObserver observer)
    {
        if (!observadores.Contains(observer))
        {
            observadores.Add(observer);
        }
    }

    public void RemoverObservador(IObserver observer)
    {
        if (observadores.Contains(observer))
        {
            observadores.Remove(observer);
        }
    }

    public void Notificar(Vector3 nuevaPosicion, int playerID)
    {
        foreach (var observer in observadores)
        {
            observer.ActualizarCheckpoint(nuevaPosicion, playerID);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
         if (other.tag == "Player")
        {
            photonView = other.GetComponent<PhotonView>();
            if (photonView != null)
            {
                playerID = photonView.Owner.ActorNumber;
                Notificar(transform.position, playerID);
                gameObject.SetActive(false);
            }            
        }
    }

}
