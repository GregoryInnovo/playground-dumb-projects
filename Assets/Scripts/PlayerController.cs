using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float fallThreshold = -10f;
    public Vector3 startPosition = new Vector3(0, 0.5f, 0);

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Check if fallen off the plane
        if (transform.position.y < fallThreshold)
        {
            ResetPosition();
        }

        // Simple ground check
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f);
        
        // Jump control
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
    
    void FixedUpdate()
    {
        // Get input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput) * moveSpeed * Time.fixedDeltaTime;
        
        // Apply movement (using MovePosition for physics-based movement)
        Vector3 newPosition = rb.position + movement;
        rb.MovePosition(newPosition);
    }
    
    void ResetPosition()
    {
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = startPosition;
    }
}
