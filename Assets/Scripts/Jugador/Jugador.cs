using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Jugador : MonoBehaviour
{
    [SerializeField] 
    private float velocidadMovimiento;//5f
    [SerializeField] 
    private float velocidaRotacion;//200f
    [SerializeField] 
    private float fuerzaSalto;
    [SerializeField] 
    private LayerMask mask;
    [SerializeField] 
    private Image sistemaVida;
    [SerializeField] 
    private float maxVida;
    [SerializeField]
    private string escenaACargar;

    private Movimiento movimiento;
    private Salto salto;
    private Vida vida;
    private Animator anim;
    private Rigidbody rb;

    private bool haCaido;

    public object Vida { get; internal set; }

    void Start()
    {
        haCaido = false;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        movimiento = new Movimiento(transform, velocidadMovimiento, velocidaRotacion);
        salto = new Salto(rb, fuerzaSalto, mask);
        vida = new Vida(maxVida, sistemaVida);
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        movimiento.Mover(x, y);
        anim.SetFloat("velX", x);
        anim.SetFloat("velY", y);

        if (Input.GetKeyDown(KeyCode.Space) && salto.EstaEnTierra(transform))
        {
            anim.Play("jump");
            salto.Saltar();
        }

        if (vida.EstaMuerto())
        {
            Muerte();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Destructor"))
        {
            // Aplicar el daño desde aquí
            vida.TomarDaño(1.0f);  // O la cantidad de daño que corresponda
            haCaido = true;
            StartCoroutine(TiempoInmunidad());
            
        }
    }


    private IEnumerator TiempoInmunidad()
    {
        yield return new WaitForSeconds(1.5f); // Espera un tiempo antes de permitir otra colisión//Equipo de balance cambiar esto
        haCaido = false; // Habilita nuevamente la colisión
    }

    private void Muerte()
    {
        SceneManager.LoadScene(escenaACargar);
    }
}
