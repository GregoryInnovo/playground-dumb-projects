using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollABallCameraController : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;
    
    void Start()
    {
        // Calculamos el offset inicial entre la cámara y el jugador
        offset = transform.position - player.transform.position;
    }
    
    void LateUpdate()
    {
        // Actualizamos la posición de la cámara para seguir al jugador con el offset
        transform.position = player.transform.position + offset;
    }
}
