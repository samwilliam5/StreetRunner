using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    // jumpForce = how high the player jumps
    public float jumpForce = 10f;

    // maxJumps = how many times player can jump
    // 2 = double jump allowed!
    private int maxJumps = 2;

    // jumpsRemaining = how many jumps player has left
    // starts at 2, goes down each jump, resets when landing
    private int jumpsRemaining = 2;

    // rb = stores the Rigidbody2D component of the player
    private Rigidbody2D rb;

    // audioSource = the speaker attached to the player
    private AudioSource audioSource;

    // jumpSound = the jump sound effect file
    public AudioClip jumpSound;

    // gameOverSound = the game over sound effect file
    public AudioClip gameOverSound;

    // Start() = runs once when game starts
    void Start()
    {
        // Get the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();

        // Get the AudioSource component
        audioSource = GetComponent<AudioSource>();
    }

    // Update() = runs every frame
    void Update()
    {
        // If Space bar pressed AND player has jumps remaining
        if (Keyboard.current.spaceKey.wasPressedThisFrame && jumpsRemaining > 0)
        {
            // Push player upward
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);

            // Play jump sound
            audioSource.PlayOneShot(jumpSound);

            // Reduce jumps remaining by 1
            // First jump → jumpsRemaining goes from 2 to 1
            // Second jump → jumpsRemaining goes from 1 to 0
            // No more jumps until landing!
            jumpsRemaining--;
        }
    }

    // OnCollisionEnter2D = runs when player touches another object
    void OnCollisionEnter2D(Collision2D collision)
    {
        // If player lands on Ground — reset jumps!
        if (collision.gameObject.name == "Ground")
        {
            // Reset jumps back to max
            jumpsRemaining = maxJumps;
        }

        // If player hits Obstacle — trigger Game Over!
        if (collision.gameObject.name.Contains("Obstacle"))
        {
            // Play game over sound
            audioSource.PlayOneShot(gameOverSound);

            // Trigger Game Over
            FindAnyObjectByType<GameManager>().GameOver();
        }
    }
}