using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Ahora la barra de vida es manejada aparte
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    [SerializeField] private HealthPoints healthPoints;

    private void Start()
    {
        GameObject hp = GameObject.Find("BarraDeVida");
        healthBar = hp.GetComponent<Image>();
    }
    public void UpdateHealthBar(float currentHealth)
    {
        healthBar.fillAmount = currentHealth / healthPoints.MaxHealth;
    }
}
