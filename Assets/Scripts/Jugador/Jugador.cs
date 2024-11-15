using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class Jugador : MonoBehaviour
{
    [SerializeField] private LayerMask mask;
    [SerializeField] private float velocidadMovimiento;//5f
    [SerializeField] private float velocidaRotacion;//200f
    [SerializeField] private float fuerzaSalto;
    private bool invulnerable;

    private Movimiento movimiento;
    private Salto salto;
    private Vida Vida;
    private Animator anim;
    private Rigidbody rb;

    [SerializeField]
    private Camera playerCamera; // Referencia a la c�mara del jugador
    private PhotonView photonView; //Red Photon

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        movimiento = new Movimiento(transform, velocidadMovimiento, velocidaRotacion);
        salto = new Salto(rb, fuerzaSalto, mask);
        photonView = GetComponent<PhotonView>();
        playerCamera = GetComponentInChildren<Camera>();
        if (photonView.IsMine)
        {
            playerCamera.gameObject.SetActive(true); // Activa la c�mara para este jugador
            Vida = GameObject.Find("BarraDeVida").GetComponent<Vida>();
        }
        else
        {
            playerCamera.gameObject.SetActive(false); // Desactiva la c�mara para otros jugadores
        }

        invulnerable = false;

    }

    void Update()
    {

        Movement();

        if (Vida.EstaMuerto())
        {
            PhotonNetwork.Disconnect();
            Muerte();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Destructor") && (photonView.IsMine))
        {
            if (!invulnerable)
            {
                photonView.RPC("AplicarDa�o", RpcTarget.AllBuffered);
            }
            invulnerable = true;
            StartCoroutine(TiempoInvulnerabilidad());
        }
    }

    [PunRPC]
    void AplicarDa�o()
    {
        Vida.TomarDa�o();
    }
    private void Movement()
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
    }

    //Metodo para evitar que se tome multiple instancias de da�o al caer muy rapido
    private IEnumerator TiempoInvulnerabilidad()
    {
        yield return new WaitForSeconds(0.5f); // Espera un tiempo antes de permitir otra colisi�n
        invulnerable = false; // Habilita nuevamente la colisi�n
    }

    private void Muerte()
    {
        SceneManager.LoadScene("MenuGameOver");
    }
}

