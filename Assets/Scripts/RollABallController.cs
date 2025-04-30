using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollABallController : MonoBehaviour
{
    public float speed = 5.0f;
    
    private Rigidbody rb;
    
    void Start()
    {
        // Obtenemos el componente Rigidbody al iniciar
        rb = GetComponent<Rigidbody>();
    }
    
    void FixedUpdate()
    {
        // Capturamos el input horizontal y vertical (teclas de flecha)
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        
        // Creamos un vector con la dirección de movimiento
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        
        // Aplicamos la fuerza al Rigidbody para mover la bola
        rb.AddForce(movement * speed);
    }
}
