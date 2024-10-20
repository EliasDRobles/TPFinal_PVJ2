using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Dispara a una velocidad aleatoria
public class ShooterBehaviour : MonoBehaviour
{
    [SerializeField]
    private float velocidadXAleatoria;

    void Update()
    {
        velocidadXAleatoria = Random.Range(25, 35);
        transform.Translate(velocidadXAleatoria * Time.deltaTime ,0, 0 );
    }
    void OnTriggerEnter(Collider other)
    {
        Destroy(transform.gameObject);
    }
}
