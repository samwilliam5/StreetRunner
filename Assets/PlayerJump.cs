using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    // jumpForce = how high the player jumps
    public float jumpForce = 10f;

    // isGrounded = is the player standing on the ground?
    private bool isGrounded = true;

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
        // AudioSource = the speaker attached to Player
        audioSource = GetComponent<AudioSource>();
    }

    // Update() = runs every frame
    void Update()
    {
        // If Space bar pressed AND player is on ground
        if (Keyboard.current.spaceKey.wasPressedThisFrame && isGrounded)
        {
            // Push player upward
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);

            // Play jump sound
            // PlayOneShot = plays a sound once without interrupting other sounds
            audioSource.PlayOneShot(jumpSound);

            // Player is now in air
            isGrounded = false;
        }
    }

    // OnCollisionEnter2D = runs when player touches another object
    void OnCollisionEnter2D(Collision2D collision)
    {
        // If player lands on Ground
        if (collision.gameObject.name == "Ground")
        {
            isGrounded = true;
        }

        // If player hits Obstacle — trigger Game Over!
        if (collision.gameObject.name.Contains("Obstacle"))
        {
            // Play game over sound before game stops
            audioSource.PlayOneShot(gameOverSound);

            // Trigger Game Over
            FindAnyObjectByType<GameManager>().GameOver();
        }
    }
}