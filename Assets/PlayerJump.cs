using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    // jumpForce = how high the player jumps
    public float jumpForce = 10f;

    // maxJumps = how many times player can jump
    private int maxJumps = 2;

    // jumpsRemaining = how many jumps player has left
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
        // Check Space bar press on PC
        bool jumpPressed = Keyboard.current.spaceKey.wasPressedThisFrame;

        // Check screen tap on Mobile
        // Input.touchCount = number of fingers touching screen
        // TouchPhase.Began = finger just touched screen
        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
        {
            // Screen was tapped!
            jumpPressed = true;
        }

        // Also check mouse click — useful for testing on PC
        // Input.GetMouseButtonDown(0) = left mouse button clicked
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            jumpPressed = true;
        }

        // If jump pressed AND player has jumps remaining
        if (jumpPressed && jumpsRemaining > 0)
        {
            // Push player upward
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);

            // Play jump sound
            audioSource.PlayOneShot(jumpSound);

            // Reduce jumps remaining by 1
            jumpsRemaining--;
        }
    }

    // OnCollisionEnter2D = runs when player touches another object
    void OnCollisionEnter2D(Collision2D collision)
    {
        // If player lands on Ground — reset jumps!
        if (collision.gameObject.name == "Ground")
        {
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