using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Prefab for obstacle and coin
    public GameObject obstaclePrefab;
    public GameObject coinPrefab;

    // Spawn positions for obstacle and coin
    private Vector2 obstacleSpawnPos = new Vector2(25, 0);
    private Vector2 coinSpawnPos = new Vector2(25, 1); // Adjust as needed

    // Delay and repeat rate for spawning obstacles
    private float startDelay = 2;
    private float repeatRate = 2;

    // Reference to the PlayerController script
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        // Find and cache the PlayerController script
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

        // Start spawning obstacles
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    // Method to spawn obstacles
    void SpawnObstacle()
    {
        // Check if the game is not over
        if (!playerControllerScript.gameOver)
        {
            // Instantiate obstacle at obstacleSpawnPos
            Instantiate(obstaclePrefab, obstacleSpawnPos, Quaternion.identity);

          
            Invoke("SpawnCoin", 5f);
        }
    }

    // Method to spawn coins
    void SpawnCoin()
    {
        // Instantiate coin at coinSpawnPos
        Instantiate(coinPrefab, coinSpawnPos, Quaternion.identity);
    }
}
