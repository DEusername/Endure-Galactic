using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthSystem : MonoBehaviour
{
    public int maxHealth = 100; // Adjust this value to set the maximum health of the player
    private int currentHealth;

    public GameObject gameOverScreen;

    public Animator animator;

    private scrapSpawn scrapSpawner; // Reference to the scrapSpawn component

    private void Start()
    {
        currentHealth = maxHealth; // Set the player's initial health to the maximum health

        // Get the scrapSpawn component attached to the enemy (child of the enemy)
        scrapSpawner = GetComponent<scrapSpawn>();
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if(currentHealth <= 0)
        {
            if (tag == "Enemy")
            {
                if (scrapSpawner != null)
                {
                    if(maxHealth == 100)
                    {
                        scrapSpawner.spawnRegularScrap(transform.position);
                    }
                    else if(maxHealth > 150)
                    {
                        scrapSpawner.spawnHQScrap(transform.position);
                    }
                }
            }
            
            if(tag == "Player")
            {
                gameObject.SetActive(false);
                gameOverScreen.SetActive(true);
                animator.SetTrigger("GameOverFadeOut");
            }
            else if(name == "Carrier")
            {
                Destroy(transform.parent.gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    public int getCurrentHealth()
    {
        return currentHealth;
    }

    public void setCurrentHealth(int newHealth)
    {
        currentHealth = newHealth;
    }
}
