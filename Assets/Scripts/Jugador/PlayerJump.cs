using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Este script solo se encarga del salto (SRP) y permite la extension (OCP)
public class PlayerJump : MonoBehaviour
{
    [SerializeField] private LayerMask mask;
    [SerializeField] private bool onAir; public bool OnAir { get => onAir; }
    [SerializeField] private float jumpForce;//5
    [SerializeField] private PlayerInput playerInput;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        playerInput = GetComponent<PlayerInput>();
        IsOnAir(transform);
        if (playerInput.Space && !onAir)
        {
            Jump();
        }        
    }

    public bool IsOnAir(Transform transform)
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 0.6f, mask))
        {
            onAir = false;
        }
        else
        {
            onAir = true;
        }
        return onAir;
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
