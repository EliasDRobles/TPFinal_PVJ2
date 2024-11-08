using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class Jugador : MonoBehaviour
{
    [SerializeField]
    private LayerMask mask;
    [SerializeField] 
    private float velocidadMovimiento;//5f
    [SerializeField] 
    private float velocidaRotacion;//200f
    [SerializeField] 
    private float fuerzaSalto;
    [SerializeField]
    private string escenaACargar;
    private Movimiento movimiento;
    private Salto salto;
    [SerializeField]
    private Vida Vida;
    private Animator anim;
    private Rigidbody rb;
    [SerializeField]
    private bool haCaido;
    [SerializeField] 
    private Camera playerCamera; // Referencia a la cámara del jugador
    private PhotonView photonView;

    void Start()
    {
        photonView = GetComponent<PhotonView>();
        playerCamera = GetComponentInChildren<Camera>();
        if (photonView.IsMine)
        {
            playerCamera.gameObject.SetActive(true); // Activa la cámara para este jugador
        }
        else
        {
            playerCamera.gameObject.SetActive(false); // Desactiva la cámara para otros jugadores
        }
        Vida = GameObject.Find("BarraDeVida").GetComponent<Vida>();
        haCaido = false;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        movimiento = new Movimiento(transform, velocidadMovimiento, velocidaRotacion);
        salto = new Salto(rb, fuerzaSalto, mask);
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

        /*if (vida.EstaMuerto())
        {
            Muerte();
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Destructor"))
        {
            // Aplicar el daño desde aquí
            if (!haCaido)
            {
                Vida.TomarDaño();  // O la cantidad de daño que corresponda
            }            
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
