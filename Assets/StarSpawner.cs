using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    // starPrefab = the star template we will create
    public GameObject starPrefab;

    // numberOfStars = how many stars to spawn at start
    public int numberOfStars = 50;

    // Start() = runs once when game starts
    void Start()
    {
        // Spawn all stars when game starts
        SpawnStars();
    }

    // SpawnStars() = creates all stars in random positions
    void SpawnStars()
    {
        for (int i = 0; i < numberOfStars; i++)
        {
            // Random position across the whole screen
            // Random.Range = picks a random number between two values
            float randomX = Random.Range(-12f, 12f);
            float randomY = Random.Range(-1f, 5f);
            Vector3 spawnPosition = new Vector3(randomX, randomY, 0f);

            // Instantiate = create a copy of starPrefab
            Instantiate(starPrefab, spawnPosition, Quaternion.identity);
        }
    }
}