using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    // obstaclePrefab = the Obstacle template we saved
    public GameObject obstaclePrefab;

    // spawnTime = how many seconds between each obstacle spawn
    private float spawnTime = 3f;

    // timer = counts time between spawns
    private float timer = 0f;

    // Update() = runs every frame
    void Update()
    {
        // Add time every frame
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
        Vector3 spawnPosition = new Vector3(10f, -3f, 0f);
        GameObject obstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);

        // Set red color immediately after spawning
        SpriteRenderer sr = obstacle.GetComponentInChildren<SpriteRenderer>();

        sr.color = new Color(1f, 0.2f, 0.2f, 1f);

        int sizeType = Random.Range(1, 4);

        if (sizeType == 1)
        {
            obstacle.transform.localScale = new Vector3(1f, 0.5f, 1f);
            obstacle.transform.position = new Vector3(10f, -3.5f, 0f);
        }
        else if (sizeType == 2)
        {
            obstacle.transform.localScale = new Vector3(1f, 1f, 1f);
            obstacle.transform.position = new Vector3(10f, -3f, 0f);
        }
        else if (sizeType == 3)
        {
            obstacle.transform.localScale = new Vector3(1f, 2f, 1f);
            obstacle.transform.position = new Vector3(10f, -2.5f, 0f);
        }
    }
}