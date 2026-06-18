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

    // dustEffect = the dust particle prefab
    // spawns when player lands on ground
    public GameObject dustEffect;

    // Start() = runs once when game starts
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update() = runs every frame
    void Update()
    {
        bool jumpPressed = Keyboard.current.spaceKey.wasPressedThisFrame;

        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
        {
            jumpPressed = true;
        }

        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            jumpPressed = true;
        }

        if (jumpPressed && jumpsRemaining > 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            audioSource.PlayOneShot(jumpSound);
            jumpsRemaining--;
        }
    }

    // OnCollisionEnter2D = runs when player touches another object
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            // Reset jumps
            jumpsRemaining = maxJumps;

            // Spawn dust effect at player feet!
            // transform.position = player current position
            // Quaternion.identity = no rotation
            if (dustEffect != null)
            {
                Instantiate(
                    dustEffect,
                    new Vector3(transform.position.x, transform.position.y - 0.5f, 0f),
                    Quaternion.identity
                );
            }
        }

        if (collision.gameObject.name.Contains("Obstacle"))
        {
            audioSource.PlayOneShot(gameOverSound);
            FindAnyObjectByType<GameManager>().GameOver();
        }
    }
}