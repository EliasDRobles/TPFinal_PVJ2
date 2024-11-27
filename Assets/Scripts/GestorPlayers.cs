using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class GestorPlayers : MonoBehaviourPunCallbacks
{
    private bool playersFound = false;  // Flag para verificar si ambos jugadores han sido encontrados
    private GameObject player1 = null;
    private GameObject player2 = null;

    void Update()
    {
        // Solo continuar si los jugadores aún no han sido encontrados
        if (playersFound) return;

        // Encuentra todos los GameObjects en la escena
        GameObject[] allObjects = FindObjectsOfType<GameObject>();

        // Recorre todos los objetos y busca aquellos que tengan "NewPlayer(Clone)" en el nombre
        foreach (GameObject obj in allObjects)
        {
            // Verifica si el objeto tiene el nombre correcto
            if (obj.name.Contains("NewPlayer(Clone)"))
            {
                // Si aún no se ha encontrado el jugador 1, asignarlo
                if (player1 == null)
                {
                    player1 = obj;
                    Debug.Log("Jugador 1 encontrado: " + player1.name);

                    // Acceder al componente HealthPoints del jugador 1
                    HealthPoints healthScript1 = player1.GetComponent<HealthPoints>();
                    if (healthScript1 != null)
                    {
                        Debug.Log("Vida del Jugador 1: " + healthScript1.CurrentHealth);
                    }
                }
                // Si ya se encontró el jugador 1, asignar el jugador 2 solo si no ha sido asignado aún
                else if (player1 != null && player2 == null)
                {
                    // Verifica si el objeto encontrado no es el mismo que el jugador 1
                    if (obj != player1)
                    {
                        player2 = obj;
                        Debug.Log("Jugador 2 encontrado: " + player2.name);

                        // Acceder al componente HealthPoints del jugador 2
                        HealthPoints healthScript2 = player2.GetComponent<HealthPoints>();
                        if (healthScript2 != null)
                        {
                            Debug.Log("Vida del Jugador 2: " + healthScript2.CurrentHealth);
                        }
                    }
                }
            }
        }

        // Si ambos jugadores han sido encontrados, detener la búsqueda en el Update
        if (player1 != null && player2 != null)
        {
            playersFound = true;
            Debug.Log("Ambos jugadores han sido encontrados. Se detiene la búsqueda.");
        }
    }

    public void EndGame()
    {
        photonView.RPC("DisconnectPlayersAndChangeScene", RpcTarget.All);
    }
    [PunRPC]
    public void DisconnectPlayersAndChangeScene()
    {
        // Primero, salimos de la sala. Este método es llamado solo una vez por cada jugador.
        PhotonNetwork.LeaveRoom();  // Esto debería asegurar que todos los jugadores dejen la sala
        PhotonNetwork.LoadLevel("MenuGameOver");
    }

    // Cuando un jugador deja la sala
    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        Debug.Log("Jugador ha dejado la sala.");
        PhotonNetwork.Disconnect();  // Desconectamos después de salir de la sala
    }
}
