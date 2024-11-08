using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class GestorPhoton : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        PhotonNetwork.JoinOrCreateRoom("Cuarto", new RoomOptions { MaxPlayers = 2 }, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        int playerID = PhotonNetwork.LocalPlayer.ActorNumber;
        switch (playerID)
        {
            case 1:
                PhotonNetwork.Instantiate("Jugador", new Vector3(-6, 0, 0), Quaternion.identity);
                break;
            case 2:
                PhotonNetwork.Instantiate("Jugador", new Vector3(6, 0, 0), Quaternion.identity);                
                break;
        }        
    }
}
