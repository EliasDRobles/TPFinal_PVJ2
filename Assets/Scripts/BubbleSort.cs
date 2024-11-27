using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class BubbleSort : MonoBehaviourPun
{
    [Header("Gestor de Distancias")]
    public DistanceObject distanceObject; // Aquí se gestionan las distancias de los jugadores

    [Header("Imágenes del Canvas")]
    public List<RectTransform> playerImages; // Las imágenes a mover en el Canvas

    private bool positionsChanged = false; // Para saber si las posiciones se han actualizado

    void Update()
    {
        // Asegurarnos de que haya al menos dos jugadores y que haya imágenes para comparar
        if (distanceObject.players.Count < 2 || playerImages.Count < 2) return;

        // Solo proceder si ambos jugadores están presentes
        if (PhotonNetwork.IsMasterClient)
        {
            // El Master Client decide cuándo ordenar y actualizar las posiciones
            UpdatePlayerPositions();
        }
    }

    private void UpdatePlayerPositions()
    {
        // Obtener las distancias de cada jugador al objeto de referencia
        List<float> distances = distanceObject.distances;

        // Comprobamos las distancias
        if (distances[0] < distances[1])
        {
            // El jugador 1 está más cerca, aseguramos que esté en la primera posición de la imagen
            if (playerImages[0].anchoredPosition != playerImages[1].anchoredPosition)
            {
                SwapImagePositions(0, 1);
                positionsChanged = true;
            }
        }
        else if (distances[0] > distances[1])
        {
            // El jugador 2 está más cerca, aseguramos que esté en la primera posición de la imagen
            if (playerImages[1].anchoredPosition != playerImages[0].anchoredPosition)
            {
                SwapImagePositions(1, 0);
                positionsChanged = true;
            }
        }

        // Si no hubo cambios, se puede registrar en el log
        if (!positionsChanged)
        {
            Debug.Log("No hubo cambios en las posiciones.");
        }
    }

    // Método para intercambiar las posiciones de las imágenes
    private void SwapImagePositions(int index1, int index2)
    {
        // Intercambiar las posiciones de las imágenes en el Canvas
        Vector2 tempPosition = playerImages[index1].anchoredPosition;
        playerImages[index1].anchoredPosition = playerImages[index2].anchoredPosition;
        playerImages[index2].anchoredPosition = tempPosition;

        // Llamar RPC para que todos los clientes intercambien las posiciones
        photonView.RPC("SwapImages", RpcTarget.Others, index1, index2);
    }

    // RPC para sincronizar el intercambio de posiciones entre todos los clientes
    [PunRPC]
    public void SwapImages(int index1, int index2)
    {
        // Intercambiar las posiciones de las imágenes en el Canvas
        Vector2 tempPosition = playerImages[index1].anchoredPosition;
        playerImages[index1].anchoredPosition = playerImages[index2].anchoredPosition;
        playerImages[index2].anchoredPosition = tempPosition;
    }
}
