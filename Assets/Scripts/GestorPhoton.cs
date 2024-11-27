using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class GestorPhoton : MonoBehaviourPunCallbacks
{
    // Lista para almacenar los jugadores conectados
    [SerializeField] private List<GameObject> playersInRoom = new List<GameObject>();

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
        PhotonNetwork.JoinOrCreateRoom("Juego", new RoomOptions { MaxPlayers = 2 }, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        int playerID = PhotonNetwork.LocalPlayer.ActorNumber;
        PhotonNetwork.NickName = "Jugador_" + PhotonNetwork.LocalPlayer.ActorNumber;

        GameObject newPlayer = null;

        // Instanciamos el objeto del jugador basado en ActorNumber
        Debug.Log("Jugador unido a la sala");

        if (PhotonNetwork.LocalPlayer.ActorNumber == 1)
        {
            Debug.Log("Jugador 1 conectado");
            newPlayer = PhotonNetwork.Instantiate("NewPlayer", new Vector3(-6, 0, 0), Quaternion.identity);
        }
        else if (PhotonNetwork.LocalPlayer.ActorNumber == 2)
        {
            Debug.Log("Jugador 2 conectado");
            newPlayer = PhotonNetwork.Instantiate("NewPlayer", new Vector3(6, 0, 0), Quaternion.identity);
        }

        if (newPlayer != null)
        {
            playersInRoom.Add(newPlayer);
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log($"Jugador {newPlayer.NickName} se ha conectado.");
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.Log($"Jugador {otherPlayer.NickName} se ha desconectado.");
    }

    public List<GameObject> GetPlayersInRoom()
    {
        return playersInRoom;
    }
}
