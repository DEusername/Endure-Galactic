using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 2f;
    public int maxEnemies = 5;

    private int currentEnemyCount = 0;
    private List<GameObject> spawnedEnemies = new List<GameObject>();

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true) // Infinite loop to continuously spawn enemies
        {
            // Check the number of active enemies in the scene
            int activeEnemyCount = GetActiveEnemyCount();

            // Only spawn new enemies if the active enemy count is less than the maximum allowed
            if (activeEnemyCount < maxEnemies)
            {
                GameObject newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
                newEnemy.transform.rotation = transform.rotation;
                spawnedEnemies.Add(newEnemy); // Add the new enemy to the list
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    int GetActiveEnemyCount()
    {
        int count = 0;
        foreach (GameObject enemy in spawnedEnemies)
        {
            if (enemy != null) // Check if the enemy object is not destroyed
            {
                count++;
            }
        }
        return count;
    }

    // Method to reduce the enemy count when an enemy is destroyed or despawned
    public void EnemyDestroyed(GameObject enemy)
    {
        if (spawnedEnemies.Contains(enemy))
        {
            spawnedEnemies.Remove(enemy); // Remove the enemy from the list
            currentEnemyCount--;
        }
    }
}
