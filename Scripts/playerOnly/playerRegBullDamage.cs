using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerRegBullDamage : MonoBehaviour
{
    public GameObject hit_effect;

    public int damageAmount = 20; // Adjust this value to set the damage inflicted by the bullet

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            healthSystem healthSystem = other.GetComponent<healthSystem>();
            if (healthSystem != null)
            {
                Instantiate(hit_effect, transform.position, Quaternion.identity);
                healthSystem.TakeDamage(damageAmount);
            }

            Destroy(gameObject); // Destroy the bullet when it hits the player
        }
    }
}
