using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class HealthPoints : MonoBehaviour
{
    [SerializeField] private float maxHealth;    public float MaxHealth { get => maxHealth; }
    [SerializeField] private float currentHealth; public float CurrentHealth { get => currentHealth; }
    private bool invulnerable;
    private HealthBar hitPoints;
    private GestorPlayers gestorPlayers;    
    private PhotonView photonView;


    void Start()
    {
        currentHealth = maxHealth;
        hitPoints = GetComponent<HealthBar>();
        gestorPlayers = FindObjectOfType<GestorPlayers>();
        photonView = GetComponent<PhotonView>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Destructor") && photonView.IsMine)
        {
            if (!invulnerable)
            {
                TakeDamage();
                hitPoints.UpdateHealthBar(currentHealth);
                
            }
            invulnerable = true;
            StartCoroutine(InvulnerableTime());
            if (currentHealth > 0) return;
            gestorPlayers.EndGame();
        }
    }

    private IEnumerator InvulnerableTime()// Esperar un tiempo antes de permitir otra colisión
    {
        yield return new WaitForSeconds(0.5f); 
        invulnerable = false;
    }

    private void TakeDamage()
    {
        currentHealth -= 1f;        
    }
}
