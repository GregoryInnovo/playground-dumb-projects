using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset = new Vector3(0, 7, -7);
    public Vector3 rotation = new Vector3(40, 0, 0);
    
    void Start()
    {
        // Try to find the player if no target is set
        if (target == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                target = player.transform;
            }
        }
        
        // Set initial camera rotation
        transform.eulerAngles = rotation;
    }
    
    void LateUpdate()
    {
        if (target == null)
            return;
            
        // Calculate desired position
        Vector3 desiredPosition = target.position + offset;
        
        // Smoothly move towards that position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
        
        // Camera keeps looking at the target
        transform.LookAt(target);
    }
}
