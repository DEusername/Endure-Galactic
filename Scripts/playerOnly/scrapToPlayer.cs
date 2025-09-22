using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrapToPlayer : MonoBehaviour
{
    public int scrapValue = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            scrapCollection scrapCount = other.GetComponent<scrapCollection>();
            if (scrapCount != null)
            {
                scrapCount.addScrap(scrapValue);
            }

            Destroy(gameObject); // Destroy the bullet when it hits the player
        }
    }
}
