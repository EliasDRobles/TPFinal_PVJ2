using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

// Este script solo se encarga de la c�mara (SRP), (OCP)
//Uso de Photon para darle al jugador su propia c�mara.
public class PlayerCam : MonoBehaviour
{
    [SerializeField]
    private Camera playerCamera; // Referencia a la c�mara del jugador
    private PhotonView photonView;

   
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        playerCamera = GetComponentInChildren<Camera>();        
        if (photonView.IsMine)
        {
            playerCamera.gameObject.SetActive(true); // Activa la c�mara para este jugador
        }
        else
        {
            playerCamera.gameObject.SetActive(false); // Desactiva la c�mara para otros jugadores
        }
    }
}
