using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ZonaReinicio : MonoBehaviour, IObserver
{
    [SerializeField]
    private Transform[] playerZoneReset;
    [SerializeField]
    private GameObject objectZoneReset;
    public float daño = 1.0f;
    [SerializeField] private ObjectPool objectPool;

    private List<CambiarCheckpoint> sujetosRegistrados = new List<CambiarCheckpoint>();
    void Start()
    {
        // Registra a los observadores que posean el script CambiarCheckpoint
        CambiarCheckpoint[] checkpoints = FindObjectsOfType<CambiarCheckpoint>();
        foreach (var checkpoint in checkpoints)
        {
            checkpoint.AgregarObservador(this);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PhotonView photonView = other.GetComponent<PhotonView>();
            if(photonView != null)
            {
                int playerID = photonView.Owner.ActorNumber;
                switch (playerID)
                {
                    case 1:                        
                        other.transform.position = playerZoneReset[0].transform.position;
                        break;
                    case 2:
                        other.transform.position = playerZoneReset[1].transform.position;
                        break;
                }
            }
        }


        if (other.gameObject.CompareTag("Objeto"))
        {
            objectPool.DevolverObjeto(other.gameObject);
        }
    }

    //Observer// Se produce un cambio de posicion en respuesta a la notificacion
    public void ActualizarCheckpoint(Vector3 nuevaPosicion, int playerID)
    {
        switch (playerID)
        {
            case 1:
                playerZoneReset[0].transform.position = nuevaPosicion;
                break;
            case 2:
                playerZoneReset[1].transform.position = nuevaPosicion;
                break;
        }
        foreach (var sujeto in sujetosRegistrados)
        {
            sujeto.RemoverObservador(this); // Llama al método RemoverObservador
        }
        sujetosRegistrados.Clear(); // Limpia la lista para evitar múltiples intentos de remoción
    }
}
