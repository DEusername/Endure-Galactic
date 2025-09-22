using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class scrapTextUpdater : MonoBehaviour
{
    public scrapCollection playerScrapSys;
    private TextMeshProUGUI scrapText; // Reference to the TextMeshProUGUI component for displaying scrap

    private void Start()
    {
        if (playerScrapSys == null)
        {
            Debug.LogError("HealthSystem reference is not set in HealthTextUpdater!");
            enabled = false;
        }

        // Try to find the Text component on the same GameObject
        scrapText = GetComponent<TextMeshProUGUI>();

        // Check if the Text component is found
        if (scrapText == null)
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
        int currentScrap = playerScrapSys.getCurrentScrap();

        // Update the health text with the current health value
        scrapText.text = "Scrap: " + currentScrap.ToString();
    }
}
