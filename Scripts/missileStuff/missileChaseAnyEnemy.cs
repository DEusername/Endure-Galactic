using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missileChaseAnyEnemy : MonoBehaviour
{
    public float speed = 2.5f; // Adjust this value to control the movement speed

    public GameObject enemyFlyer;
    private Transform currentTarget;

    private void Start()
    {
        FindTarget();
    }

    void Update()
    {
        if (playerMovement.playerInstance != null && currentTarget != null)
        {
            Vector3 directionToCurrentTarget = currentTarget.transform.position - transform.position;
            float angle = Mathf.Atan2(directionToCurrentTarget.y, directionToCurrentTarget.x) * Mathf.Rad2Deg - 90f;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            // Move the object forward based on its local forward direction
            transform.Translate(transform.up * speed * Time.deltaTime);
            currentTarget = null;
        }

        if(currentTarget == null)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
    }

    private void FindTarget()
    {
        // Find all enemy flyers in the scene
        GameObject[] enemyFlyers = GameObject.FindGameObjectsWithTag("Enemy");

        // Initialize variables to track the closest enemy and its distance
        float closestDistance = Mathf.Infinity;
        Transform closestEnemy = null;

        if (enemyFlyers.Length == 0)
        {
            Destroy(gameObject);
        }

        // Iterate through all enemy flyers to find the closest one
        foreach (GameObject enemyFlyer in enemyFlyers)
        {
            // Calculate the distance between the missile and the enemy flyer
            float distanceToEnemy = Vector3.Distance(transform.position, enemyFlyer.transform.position);

            // If the current enemy is closer than the closest enemy found so far, update the closestEnemy and closestDistance variables
            if (distanceToEnemy < closestDistance)
            {
                closestDistance = distanceToEnemy;
                closestEnemy = enemyFlyer.transform;
            }

            // Update the current target with the closest enemy's transform
            currentTarget = closestEnemy;
        }
    }
}
