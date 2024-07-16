using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script manages the spawning of collectible objects in the game
public class GameManager : MonoBehaviour
{
    // The prefab of the collectible object to be instantiated
    public GameObject collectiblePrefab;

    // The minimum and maximum positions for spawning collectibles
    public Vector3 spawnAreaMin;
    public Vector3 spawnAreaMax;

    // The number of collectibles to spawn at the start of the game
    public int initialCollectibles = 5;

    // Start is called before the first frame update
    void Start()
    {
        // Loop to spawn the initial number of collectibles
        for (int i = 0; i < initialCollectibles; i++)
        {
            // Call the method to instantiate a collectible at a random position
            InstantiateRandomCollectible();
        }
    }

    // Method to instantiate a collectible at a random position within the defined area
    public void InstantiateRandomCollectible()
    {
        // Generate a random position within the specified range
        Vector3 randomPosition = new Vector3(
            Random.Range(spawnAreaMin.x, spawnAreaMax.x),
            Random.Range(spawnAreaMin.y, spawnAreaMax.y),
            Random.Range(spawnAreaMin.z, spawnAreaMax.z)
        );

        // Instantiate the collectible at the random position with no rotation
        Instantiate(collectiblePrefab, randomPosition, Quaternion.identity);
    }
}
