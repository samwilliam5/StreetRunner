using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce = 10f;
    private int maxJumps = 2;
    private int jumpsRemaining = 2;
    private Rigidbody2D rb;
    private AudioSource audioSource;
    public AudioClip jumpSound;
    public AudioClip gameOverSound;
    public GameObject dustEffect;
    public GameObject hintText; // drag HintText here

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        bool jumpPressed = Keyboard.current.spaceKey.wasPressedThisFrame;

        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
            jumpPressed = true;

        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
            jumpPressed = true;

        if (jumpPressed && jumpsRemaining > 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            audioSource.PlayOneShot(jumpSound);
            jumpsRemaining--;

            // Hide hint on first jump
            if (hintText != null)
                hintText.SetActive(false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            jumpsRemaining = maxJumps;

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