using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject collectiblePrefab;
    public Vector3 spawnAreaMin;
    public Vector3 spawnAreaMax;
    public int initialCollectibles = 5;

    void Start()
    {
        for (int i = 0; i < initialCollectibles; i++)
        {
            InstantiateRandomCollectible();
        }
    }

    public void InstantiateRandomCollectible()
    {
        Vector3 randomPosition = new Vector3(
            Random.Range(spawnAreaMin.x, spawnAreaMax.x),
            Random.Range(spawnAreaMin.y, spawnAreaMax.y),
            Random.Range(spawnAreaMin.z, spawnAreaMax.z)
        );

        Instantiate(collectiblePrefab, randomPosition, Quaternion.identity);
    }
}