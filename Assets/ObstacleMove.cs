using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    // moveSpeed = how fast obstacle moves toward player
    // starts at 5f and increases over time
    public float moveSpeed = 3f;

    // maxSpeed = maximum speed obstacle can reach
    // we dont want it going too crazy fast!
    private float maxSpeed = 10f;

    // speedIncreaseRate = how fast the speed increases
    // every second speed goes up by this amount
    private float speedIncreaseRate = 0.5f;

    // Update() = runs every frame
    void Update()
    {
        // Increase speed over time
        // Mathf.Min = never goes above maxSpeed
        moveSpeed = Mathf.Min(maxSpeed, moveSpeed + speedIncreaseRate * Time.deltaTime);

        // Move obstacle to the LEFT every frame
        // Vector2.left = move in left direction
        // Time.deltaTime = move smoothly on all computers
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

        // If obstacle goes too far left — destroy it
        if (transform.position.x < -15f)
        {
            Destroy(gameObject);
        }
    }
}