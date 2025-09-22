using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletDespawn : MonoBehaviour
{
    public float lifetime = 3f; // Adjust this value to set the lifetime of the bullet
    private float timer = 0f;

    void Update()
    {
        // Increment the timer
        timer += Time.deltaTime;

        if (timer >= lifetime)
        {
            // Destroy the bullet when it exceeds the lifetime or maximum distance from the player
            Destroy(gameObject);
        }
    }
}
