using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private float VelMov = 5f;     // Velocidad de movimiento del parsonaje
    [SerializeField] private float VelRot = 200f;   // Velocidad de rotacion en el eje Y
    private Animator anim;  // accedemos a las propiedades del componente Animator 
    public float x, y;
    public float speedZ=5f;    
    public bool enTierra;  // se usa para el contacto del cuerpo del personaje con la tierra
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private float fuerzaSalto; // Fuerza de salto
    public LayerMask Mask; // layer del suelo para indicar si esta en el suelo
    //Sistema de vida
    public float maxVida;
    public float actualVida;
    public Image sistemaVida;
    public float ActualVida { get => actualVida; set => actualVida = value; }
    //Escena a la que se dirige al perder
    public int perder;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        actualVida = maxVida;
    }
 
    // Update is called once per frame
    void Update()
    {
       
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        transform.Rotate(0, x * Time.deltaTime * VelRot, 0);
        transform.Translate(0, 0, y * Time.deltaTime * VelMov);
      


        anim.SetFloat("velX", x); // llamamos la animacion de los pies para moverse mientras camina
     
        anim.SetFloat("velY", y); // llamamos la animacion de los pies para moverse mientras camina

        CheckTierra();

        if (Input.GetKeyDown(KeyCode.LeftControl) && enTierra ) // condicion para apretar la tecla Ctrl y verificar si estamos en tierra
        {
            anim.Play("jump"); // llamamos a la animacion de salto del Jugador
            Jump(); // llamamos el metodo salto
        }

          sistemaVida.fillAmount = actualVida / maxVida;

        if (actualVida <= 0)
        {
            Muerte();
        }
    }
    // metodo para ver si estamos tocando tierra o no y evitar saltar varias veces
    private void CheckTierra() { 
        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(transform.position, Vector3.down, out hit,0.6f,Mask)) // condicion para analizar la posicion del personaje, su vector de caida, el radio de su sphere colider y el layer con el que colisiona para analizar si saltar o no

        {
            enTierra = true;
        }
        else { 
            enTierra=false;
        }
    }
    //Metodo que permite saltar
    public void Jump() {

        rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
    }
    //Metodo que envia a la escena Game Over
    public void Muerte()
    {
        Destroy(this.gameObject);
        SceneManager.LoadScene(perder);

    }
}
