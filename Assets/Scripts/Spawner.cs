using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject balloonPrefab;
    public float spawnInterval = 3f;
    public float xMin = -7f;
    public float xMax = 7f;
    public float ySpawnPosition = -6f;
    public int minBalloonPerSpawn = 1;
    public int maxBalloonPerSpawn = 2;

    void Start()
    {
        InvokeRepeating("SpawnBalloons", 1f, spawnInterval);
    }

    void SpawnBalloons()
    {
        int balloonCount = Random.Range(minBalloonPerSpawn, maxBalloonPerSpawn + 1);
        for (int i = 0; i < balloonCount; i++)
        {
            // float xPos = Random.Range(xMin, xMax);
            // Vector2 spawnPos = new Vector2(xPos, ySpawnPosition);

            // Instantiate(balloonPrefab, spawnPos, Quaternion.identity);

            float minX = 0.05f;
            float maxX = 0.95f;
            float spawnY = 0f; // bottom of screen

            float randX = Random.Range(minX, maxX);
            Vector3 spawnPosition = Camera.main.ViewportToWorldPoint(new Vector3(randX, spawnY, 10f)); // 10 = camera distance

            Instantiate(balloonPrefab, spawnPosition, Quaternion.identity);
        }
    }


}
