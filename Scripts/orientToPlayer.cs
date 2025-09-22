using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orientToPlayer : MonoBehaviour
{
    private float maxOffset = 2f; // Maximum offset in degrees

    private float randomOffset;

    void Update()
    {
        if (playerMovement.playerInstance != null)
        {
            Vector3 directionToPlayer = playerMovement.playerInstance.transform.position - transform.position;
            float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg - 90f;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            // Calculate a random offset within the specified range
            randomOffset = Random.Range(-maxOffset, maxOffset);

            // Apply the random offset to the initial rotation
            transform.Rotate(Vector3.forward, randomOffset);
        }
    }
}
