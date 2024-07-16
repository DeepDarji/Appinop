using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public GameManager gameManager;
    public int collectibleCount = 0;
    public TextMeshProUGUI collectibleCounterText;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        collectibleCounterText = FindObjectOfType<TextMeshProUGUI>();
        UpdateCollectibleCounter();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        transform.Translate(movement * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {
            Destroy(other.gameObject);
            collectibleCount++;
            UpdateCollectibleCounter();
            gameManager.InstantiateRandomCollectible();
        }
    }

    void UpdateCollectibleCounter()
    {
        collectibleCounterText.text = "Collectibles: " + collectibleCount;
    }
}