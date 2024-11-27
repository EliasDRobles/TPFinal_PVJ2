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
    [SerializeField] private float velocidadRotacion;//200f
    [SerializeField] private float fuerzaSalto;
    private bool invulnerable;

    private Movimiento movimiento;
    private Salto salto;
    private Vida Vida;
    private Animator anim;
    private Rigidbody rb;

    [SerializeField]
    private Camera playerCamera; // Referencia a la cámara del jugador
    private PhotonView photonView; //Red Photon

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        movimiento = new Movimiento(transform, velocidadMovimiento, velocidadRotacion);
        salto = new Salto(rb, fuerzaSalto, mask);
        photonView = GetComponent<PhotonView>();
        playerCamera = GetComponentInChildren<Camera>();
        if (photonView.IsMine)
        {
            playerCamera.gameObject.SetActive(true); // Activa la cámara para este jugador
            Vida = GameObject.Find("Vida").GetComponent<Vida>();
            if (Vida == null)
            {
                Debug.LogError("No se pudo encontrar el componente Vida en la escena.");
            }
        }
        else
        {
            playerCamera.gameObject.SetActive(false); // Desactiva la cámara para otros jugadores
        }

        invulnerable = false;

    }

    void Update()
    {

        Movement();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Destructor") && (photonView.IsMine))
        {
            if (!invulnerable)
            {
                Vida.TomarDaño();
                if (Vida.VidaActual <= 0)
                {
                    NotificarGameOver();
                }
            }
            invulnerable = true;
            StartCoroutine(TiempoInvulnerabilidad());
        }
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

    //Metodo para evitar que se tome multiple instancias de daño al caer muy rapido
    private IEnumerator TiempoInvulnerabilidad()
    {
        yield return new WaitForSeconds(0.5f); // Espera un tiempo antes de permitir otra colisión
        invulnerable = false; // Habilita nuevamente la colisión
    }

    public void NotificarGameOver()
    {
        // Llama a un RPC para notificar a todos los jugadores
        photonView.RPC("CargarGameOver", RpcTarget.AllBuffered);
    }


    [PunRPC]
    private void CargarGameOver()
    {
        // Si todos están listos, carga la escena de Game Over
        PhotonNetwork.Disconnect(); 
        SceneManager.LoadScene("MenuGameOver");
        


        //GameManager.Instance.CheckGameOver();
    }
}

