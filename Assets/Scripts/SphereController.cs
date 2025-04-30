using UnityEngine;

public class SphereController : MonoBehaviour
{
    public float rotationSpeed = 50f;
    public float bounceHeight = 0.2f;
    public float bounceSpeed = 2f;
    
    private Vector3 startPosition;
    private float timeOffset;
    
    void Start()
    {
        startPosition = transform.position;
        timeOffset = Random.Range(0f, 2f * Mathf.PI); // Random start phase
    }
    
    void Update()
    {
        // Rotate the collectible
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        
        // Add a gentle bouncing motion
        float newY = startPosition.y + Mathf.Sin((Time.time + timeOffset) * bounceSpeed) * bounceHeight;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Notify the GameController to increase score
            GameController gameController = FindObjectOfType<GameController>();
            if (gameController != null)
            {
                gameController.CollectSphere();
            }
            
            // Destroy the collectible
            Destroy(gameObject);
        }
    }
}
