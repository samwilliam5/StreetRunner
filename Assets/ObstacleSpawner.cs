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
            spawnTime = Mathf.Max(0.8f, spawnTime - 0.1f);
        }
    }

    // SpawnObstacle() = creates a new obstacle in the scene
    void SpawnObstacle()
    {
        // Random.Range = picks random number between 1 and 4
        // 1 = small, 2 = medium, 3 = tall, 4 = double obstacle
        int obstacleType = Random.Range(1, 5);

        if (obstacleType == 1)
        {
            // Type 1 — Small obstacle
            SpawnSingle(10f, -3.5f, 1f, 0.5f);
        }
        else if (obstacleType == 2)
        {
            // Type 2 — Medium obstacle
            SpawnSingle(10f, -3f, 1f, 1f);
        }
        else if (obstacleType == 3)
        {
            // Type 3 — Tall obstacle — need double jump!
            SpawnSingle(10f, -2.5f, 1f, 2f);
        }
        else if (obstacleType == 4)
        {
            // Type 4 — Two obstacles close together — tricky!
            SpawnSingle(10f, -3f, 1f, 1f);
            SpawnSingle(12f, -3f, 1f, 1f);
        }
    }

    // SpawnSingle() = spawns one obstacle with given position and size
    // posX = horizontal position
    // posY = vertical position
    // scaleX = width of obstacle
    // scaleY = height of obstacle
    void SpawnSingle(float posX, float posY, float scaleX, float scaleY)
    {
        // Create obstacle at given position
        Vector3 spawnPosition = new Vector3(posX, posY, 0f);
        GameObject obstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);

        // Set size
        obstacle.transform.localScale = new Vector3(scaleX, scaleY, 1f);

        // Set red color
        // GetComponentInChildren = searches child objects too
        SpriteRenderer sr = obstacle.GetComponentInChildren<SpriteRenderer>();
        sr.color = new Color(1f, 0.2f, 0.2f, 1f);
    }
}