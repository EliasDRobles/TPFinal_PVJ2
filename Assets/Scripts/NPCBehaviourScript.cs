using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCBehaviourScript : MonoBehaviour
{
    //Se obtiene el transform de player para conocer su posicion
    public Transform player;
    //Representa a la IA usada en el juego
    private NavMeshAgent npc;
    void Start()
    {
        //Le asignamos los componentes del NavMeshAgent nuestro NPC 
        npc = GetComponent<NavMeshAgent>();
    }
    
    void Update()
    {
        //Permite al NPC dirigirse a la posicion del jugador continuamente
        npc.destination = player.position;       
    }
}
