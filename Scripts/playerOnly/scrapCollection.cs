using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrapCollection : MonoBehaviour
{
    private int scrapCollected = 0;
    public float conversionTime = 1f; // Adjust this value to set the time delay between bullet spawns
    private bool canConvert = true;

    public healthSystem playerHealthSys;
    public createBullet createBulletScript;
    private int currentHealth = 0;

    private void Start()
    {
        currentHealth = playerHealthSys.getCurrentHealth();
    }

    public void addScrap(int scrapValue)
    {
        scrapCollected += scrapValue;
    }

    public int getCurrentScrap()
    {
        return scrapCollected;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.C) && canConvert == true && scrapCollected >= 25 && playerHealthSys.getCurrentHealth() <= playerHealthSys.maxHealth - 5)
        {
            // Start the coroutine for the healing process
            StartCoroutine(HealOverTime());
        }
    }

    IEnumerator HealOverTime()
    {
        // Disable healing while it's in progress
        canConvert = false;
        createBulletScript.stopShoot();

        // Number of iterations to heal over 1 second (change as needed)
        int numIterations = 5;
        // Amount of health to heal each iteration (change as needed)
        int healAmount = 1;

        for (int i = 0; i < numIterations; i++)
        {
            // Deduct scrap for healing
            scrapCollected -= 5;

            // Increase the player's health
            int currentHealth = playerHealthSys.getCurrentHealth();
            currentHealth += healAmount;
            playerHealthSys.setCurrentHealth(currentHealth);

            // Wait for a short time before healing again
            yield return new WaitForSeconds(conversionTime / numIterations);
        }

        createBulletScript.startShoot();
        // Enable healing after the process is complete
        canConvert = true;
    }
}
