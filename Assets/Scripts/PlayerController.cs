using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// This script controls the player's movement and handles collectible interactions
public class PlayerController : MonoBehaviour
{
    // The speed at which the player moves
    public float speed = 5f;

    // Reference to the GameManager script
    public GameManager gameManager;

    // Counter for the number of collectibles collected
    public int collectibleCount = 0;

    // UI text element to display the collectible count
    public TextMeshProUGUI collectibleCounterText;

    // Start is called before the first frame update
    void Start()
    {
        // Find and reference the GameManager script in the scene
        gameManager = FindObjectOfType<GameManager>();

        // Find and reference the TextMeshProUGUI component for displaying the collectible count
        collectibleCounterText = FindObjectOfType<TextMeshProUGUI>();

        // Update the collectible counter UI at the start
        UpdateCollectibleCounter();
    }

    // Update is called once per frame
    void Update()
    {
        // Get horizontal and vertical input (arrow keys or WASD keys)
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Create a movement vector based on input
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Move the player based on the movement vector, speed, and time
        transform.Translate(movement * speed * Time.deltaTime);
    }

    // This method is called when the player collides with another collider
    void OnTriggerEnter(Collider other)
    {
        // Check if the collided object has the "Collectible" tag
        if (other.gameObject.CompareTag("Collectible"))
        {
            // Destroy the collectible object
            Destroy(other.gameObject);

            // Increase the collectible count
            collectibleCount++;

            // Update the collectible counter UI
            UpdateCollectibleCounter();

            // Instantiate a new collectible at a random position
            gameManager.InstantiateRandomCollectible();
        }
    }

    // Method to update the UI text element with the current collectible count
    void UpdateCollectibleCounter()
    {
        collectibleCounterText.text = "Collectibles: " + collectibleCount;
    }
}
