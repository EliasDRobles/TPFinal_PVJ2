using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceObject : MonoBehaviour
{
    [Header("Objeto de Referencia")]
    public GameObject referenceObject;  // Objeto para medir las distancias

    [Header("Jugadores")]
    public List<GameObject> players = new List<GameObject>();  // Lista de jugadores
    public List<float> distances = new List<float>();  // Lista de distancias calculadas

    void Update()
    {
        // Buscar y actualizar jugadores
        FindPlayers();

        // Actualizar distancias en tiempo real
        UpdateDistances();
    }

    // Método para buscar jugadores dinámicamente
    private void FindPlayers()
    {
        GameObject[] allObjects = FindObjectsOfType<GameObject>();

        foreach (GameObject obj in allObjects)
        {
            if (obj.name.Contains("NewPlayer(Clone)") && !players.Contains(obj))
            {
                players.Add(obj);
                Debug.Log("Jugador encontrado: " + obj.name);
            }
        }
    }

    // Método para actualizar las distancias de los jugadores al objeto de referencia
    private void UpdateDistances()
    {
        distances.Clear();

        foreach (GameObject player in players)
        {
            if (player != null && referenceObject != null)
            {
                float distance = Mathf.Abs(player.transform.position.z - referenceObject.transform.position.z);
                distances.Add(distance);
            }
        }
    }
}
