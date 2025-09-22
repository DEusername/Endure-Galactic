using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chasePlayer : MonoBehaviour
{
    public float speed = 5f; // Adjust this value to control the movement speed
    public float stoppingDistance = 10f;

    void Update()
    {
        if (playerMovement.playerInstance != null)
        {
            Vector3 directionToPlayer = playerMovement.playerInstance.transform.position - transform.position;
            float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg - 90f;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            if (Vector3.Distance(transform.position, playerMovement.playerInstance.transform.position) >= stoppingDistance)
            {
                // Move the object forward based on its local forward direction
                transform.Translate(Vector3.up * speed * Time.deltaTime);
            }
        }
    }
}
