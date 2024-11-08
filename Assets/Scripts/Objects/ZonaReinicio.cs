using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ZonaReinicio : MonoBehaviour
{
    [SerializeField]
    private Transform[] playerZoneReset;
    [SerializeField]
    private GameObject objectZoneReset;
    public float daño = 1.0f;    

    private void OnTriggerEnter(Collider other)
    {
        Objeto objeto = GameObject.Find("Objeto").GetComponent<Objeto>();
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
            objeto.transform.position = objectZoneReset.transform.position; ;
        }
    }
}
