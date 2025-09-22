using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class healthTextUpdater : MonoBehaviour
{
    public healthSystem playerHealthSys; // Reference to your separate HealthSystem script
    private TextMeshProUGUI healthText; // Reference to the TextMeshProUGUI component for displaying health

    private void Start()
    {
        if (playerHealthSys == null)
        {
            Debug.LogError("HealthSystem reference is not set in HealthTextUpdater!");
            enabled = false;
        }

        // Try to find the Text component on the same GameObject
        healthText = GetComponent<TextMeshProUGUI>();

        // Check if the Text component is found
        if (healthText == null)
        {
            Debug.LogError("Text component not found in HealthTextUpdater!");
            enabled = false;
        }

        // Update the health text initially
        UpdateHealthText();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealthText();
    }

    private void UpdateHealthText()
    {
        // Get the current health value from the HealthSystem script
        int currentHealth = playerHealthSys.getCurrentHealth();

        // Update the health text with the current health value
        healthText.text = "Health: " + currentHealth.ToString();
    }
}
