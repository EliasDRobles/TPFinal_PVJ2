using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Este script solo se encarga de las animaciones (SRP) y (OCP)
public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private PlayerJump playerJump;
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        playerInput = GetComponent<PlayerInput>();
        playerJump = GetComponent<PlayerJump>();
        PlayMovementAnim(playerInput.X, playerInput.Y);
        if (playerInput.Space && !playerJump.OnAir)
        {
            PlayJumpAnim();
        }        
    }

    void PlayMovementAnim(float x, float y)
    {
        anim.SetFloat("velX", x);
        anim.SetFloat("velY", y);
    }

    void PlayJumpAnim()
    {
        anim.Play("jump");
    }
}
