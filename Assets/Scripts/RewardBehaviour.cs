using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Comportamiento del premio
public class RewardBehaviour : MonoBehaviour
{
    private float giro = 50f;
    [SerializeField]
    private bool isRotating;
    public bool IsRotating { get => isRotating; set => isRotating = value; }
    private void Start()
    {
        isRotating = true;
    }
    void Update()
    {
        if (isRotating)
        {
            transform.Rotate(0, giro * Time.deltaTime, 0);
        }
        else
        {
            transform.rotation = new Quaternion(0,0,0,0);
        }
    }   
}
