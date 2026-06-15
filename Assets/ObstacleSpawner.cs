using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    // obstaclePrefab = the Obstacle template we saved
    // We will drag our Prefab into this slot in Unity
    public GameObject obstaclePrefab;

    // spawnTime = how many seconds between each obstacle spawn
    private float spawnTime = 3f;

    // timer = counts time between spawns
    private float timer = 0f;

    // Update() = runs every frame
    void Update()
    {
        // Add time every frame
        // Time.deltaTime = time since last frame
        timer += Time.deltaTime;

        // If timer reaches spawnTime → spawn obstacle
        if (timer >= spawnTime)
        {
            // Spawn the obstacle!
            SpawnObstacle();

            // Reset timer back to 0
            timer = 0f;

            // Reduce spawnTime slowly — game gets harder!
            // Mathf.Max = never goes below 0.8f seconds
            spawnTime = Mathf.Max(0.8f, spawnTime - 0.1f);
        }
    }

    // SpawnObstacle() = creates a new obstacle in the scene
    void SpawnObstacle()
    {
        // Instantiate = create a copy of the prefab in the scene
        // obstaclePrefab = the template to copy
        // spawnPosition = where to spawn it (right side of screen)
        // Quaternion.identity = no rotation
        Vector3 spawnPosition = new Vector3(10f, -3f, 0f);
        Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
    }
}