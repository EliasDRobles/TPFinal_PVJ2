using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Se encarga de devolver al jugador al inicio del nivel que se encuentre
public class ResetPlayer : MonoBehaviour
{
    [SerializeField]
    private Transform playerZoneReset;
    [SerializeField]
    private Transform objectZoneReset;
    public float daño = 1.0f;

    private void OnTriggerEnter(Collider other)
    {
        PlayerBehaviour player = GameObject.Find("Perrito").GetComponent<PlayerBehaviour>();
        RewardBehaviour reward = GameObject.Find("Premio").GetComponent<RewardBehaviour>();
        if (other.gameObject.CompareTag("Player"))
        {
            player.transform.position = playerZoneReset.transform.position;
            player.ActualVida = player.ActualVida - daño;
        }


        if (other.gameObject.CompareTag("Premio"))
        {
            reward.transform.position = objectZoneReset.transform.position; ;
        }
    }
}