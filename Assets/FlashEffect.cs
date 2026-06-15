using UnityEngine;
using UnityEngine.UI;

public class FlashEffect : MonoBehaviour
{
    // flashPanel = the red panel we created
    public Image flashPanel;

    // flashSpeed = how fast the red flash fades away
    public float flashSpeed = 8f;

    // isFlashing = is the screen currently flashing?
    private bool isFlashing = false;

    // Update() = runs every frame
    void Update()
    {
        // If flashing → fade the red color away slowly
        if (isFlashing)
        {
            // Lerp = smoothly change value from one to another
            // Color.Lerp = smoothly change color
            flashPanel.color = Color.Lerp(
                flashPanel.color,
                new Color(1, 0, 0, 0),
                flashSpeed * Time.deltaTime
            );

            // If alpha is almost invisible → stop flashing
            if (flashPanel.color.a < 0.01f)
            {
                isFlashing = false;

                // Make completely invisible
                flashPanel.color = new Color(1, 0, 0, 0.3f);
            }
        }
    }

    // Flash() = called when player hits obstacle
    public void Flash()
    {
        // Set red color with high alpha = visible red flash
        flashPanel.color = new Color(1, 0, 0, 0.5f);

        // Start fading
        isFlashing = true;
    }
}