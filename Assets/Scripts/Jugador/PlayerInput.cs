using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private float x; public float X { get => x; }
    private float y; public float Y { get => y; }
    private bool space; public bool Space { get => space; }

    
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        space = Input.GetKeyDown(KeyCode.Space);
    }
}
