using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    // camera = the Main Camera in the scene
    private Camera mainCamera;

    // cycleSpeed = how fast day/night cycle changes
    // higher = faster cycle
    public float cycleSpeed = 0.05f;

    // currentTime = tracks where we are in the cycle
    // 0 = night, 0.25 = dawn, 0.5 = day, 0.75 = dusk
    private float currentTime = 0f;

    // Define colors for each time of day
    // Color32 = color using 0-255 values like R G B
    private Color nightColor = new Color32(20, 10, 40, 255);    // dark purple night
    private Color dawnColor = new Color32(80, 40, 80, 255);     // purple/pink dawn
    private Color dayColor = new Color32(50, 120, 200, 255);    // bright blue day
    private Color duskColor = new Color32(100, 50, 30, 255);    // orange/red dusk

    // Start() = runs once when game starts
    void Start()
    {
        // Get the Main Camera
        mainCamera = Camera.main;
        // Camera.main = finds the Main Camera in the scene
    }

    // Update() = runs every frame
    void Update()
    {
        // Increase time every frame
        // Time.deltaTime = smooth increase
        currentTime += cycleSpeed * Time.deltaTime;

        // Keep currentTime between 0 and 1
        // Mathf.Repeat = loops value between 0 and 1
        currentTime = Mathf.Repeat(currentTime, 1f);

        // Change camera background color based on time
        if (currentTime < 0.25f)
        {
            // Night to Dawn
            // Mathf.InverseLerp = converts currentTime to 0-1 range
            float t = Mathf.InverseLerp(0f, 0.25f, currentTime);
            mainCamera.backgroundColor = Color.Lerp(nightColor, dawnColor, t);
        }
        else if (currentTime < 0.5f)
        {
            // Dawn to Day
            float t = Mathf.InverseLerp(0.25f, 0.5f, currentTime);
            mainCamera.backgroundColor = Color.Lerp(dawnColor, dayColor, t);
        }
        else if (currentTime < 0.75f)
        {
            // Day to Dusk
            float t = Mathf.InverseLerp(0.5f, 0.75f, currentTime);
            mainCamera.backgroundColor = Color.Lerp(dayColor, duskColor, t);
        }
        else
        {
            // Dusk to Night
            float t = Mathf.InverseLerp(0.75f, 1f, currentTime);
            mainCamera.backgroundColor = Color.Lerp(duskColor, nightColor, t);
        }
    }
}