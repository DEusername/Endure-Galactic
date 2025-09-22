using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class roundTextUpdater : MonoBehaviour
{
    public RoundSystem roundSystemInstance;
    private TextMeshProUGUI roundText; // Reference to the TextMeshProUGUI component for displaying scrap

    private void Start()
    {
        if (roundSystemInstance == null)
        {
            Debug.LogError("HealthSystem reference is not set in HealthTextUpdater!");
            enabled = false;
        }

        // Try to find the Text component on the same GameObject
        roundText = GetComponent<TextMeshProUGUI>();

        // Check if the Text component is found
        if (roundText == null)
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
        int currentScrap = roundSystemInstance.getCurrentRound();

        // Update the health text with the current health value
        roundText.text = "Round: " + currentScrap.ToString();
    }
}
