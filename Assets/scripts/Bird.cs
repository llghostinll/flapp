using UnityEngine;

public class Bird : MonoBehaviour
{
    public float flapStrength = 5f; // Strength of the bird's flap
    private Rigidbody2D rb;
    private GameManager gameManager; // Reference to the GameManager

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>(); // Find the GameManager in the scene
    }

    void Update()
    {
        // Check for input to make the bird flap
        if (Input.GetMouseButtonDown(0))
        {
            Flap();
        }
    }

    private void Flap()
    {
        // Apply an upward force to the bird
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, flapStrength);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        // Check if the bird collided with the ground or pipes
        if (collider.CompareTag("Ground") || collider.CompareTag("Pipe"))
        {
            gameManager.EndGame(); // Call the EndGame method in GameManager
            Destroy(gameObject); // Optionally destroy the bird
        }
    }
}