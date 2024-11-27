using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerCam : MonoBehaviour
{
    [SerializeField]
    private Camera playerCamera; // Referencia a la cámara del jugador
    private PhotonView photonView;

   
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        playerCamera = GetComponentInChildren<Camera>();        
        if (photonView.IsMine)
        {
            playerCamera.gameObject.SetActive(true); // Activa la cámara para este jugador
        }
        else
        {
            playerCamera.gameObject.SetActive(false); // Desactiva la cámara para otros jugadores
        }
    }
}
