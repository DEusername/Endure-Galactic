using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawnerComm : MonoBehaviour
{
    public enemySpawner spawner;

    private void OnDestroy()
    {
        if (spawner != null)
        {
            spawner.EnemyDestroyed(gameObject); // Notify the spawner that the enemy is destroyed
        }
    }
}
