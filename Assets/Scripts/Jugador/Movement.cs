using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Este script solo se encarga del movimiento (SRP) y (OCP)
public class Movement : MonoBehaviour
{
    [SerializeField] private float velocidadMovimiento;//5f
    [SerializeField] private float velocidadRotacion;//200f
    [SerializeField] private PlayerInput playerInput;
    
    void Update()
    {
        playerInput = GetComponent<PlayerInput>();
        MovePlayer(playerInput.X, playerInput.Y);
    }
    void MovePlayer(float x, float y)
    {
        transform.Rotate(0, x * Time.deltaTime * velocidadRotacion, 0);
        transform.Translate(0, 0, y * Time.deltaTime * velocidadMovimiento);
    }
}
