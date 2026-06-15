using UnityEngine;

public class ScrollingBuilding : MonoBehaviour
{
    // scrollSpeed = how fast building moves left
    // slower than obstacles so it feels like background
    public float scrollSpeed = 1f;

    // resetPositionX = when building goes this far left → reset to right
    private float resetPositionX = -15f;

    // startPositionX = where building resets to on right side
    private float startPositionX = 15f;

    // Update() = runs every frame
    void Update()
    {
        // Move building to the LEFT every frame
        // Time.deltaTime = smooth movement on all computers
        transform.Translate(Vector2.left * scrollSpeed * Time.deltaTime);

        // If building goes too far left → reset to right side
        // Creates infinite scrolling loop!
        if (transform.position.x < resetPositionX)
        {
            // Reset building back to right side
            transform.position = new Vector3(
                startPositionX,
                transform.position.y,
                transform.position.z
            );
        }
    }
}