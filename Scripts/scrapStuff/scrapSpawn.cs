using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrapSpawn : MonoBehaviour
{
    public GameObject scrapPrefab;
    public Color cyanColor = Color.cyan; // Define the cyan color here or in the Inspector

    public void spawnRegularScrap(Vector3 spawnPosition)
    {
        GameObject scrapObj = Instantiate(scrapPrefab, spawnPosition, Quaternion.identity);
    }

    public void spawnHQScrap(Vector3 spawnPosition)
    {
        Debug.Log("Spawn position" + spawnPosition);
        // create a scrap gameobject that is of the position that the parent object had.
        GameObject scrapObj = Instantiate(scrapPrefab, spawnPosition, Quaternion.identity);

        // Get the Sprite Renderer component from the instantiated object
        SpriteRenderer spriteRenderer = scrapObj.GetComponent<SpriteRenderer>();

        // Check if the Sprite Renderer component exists
        if (spriteRenderer != null)
        {
            // Change the color of the Sprite Renderer to cyan
            spriteRenderer.color = cyanColor;
        }

        scrapToPlayer instancedScrapValue = scrapObj.GetComponent<scrapToPlayer>();

        if (instancedScrapValue != null)
        {
            // Adjust the public variable of the instantiated object
            instancedScrapValue.scrapValue = 50;
        }

    }
}
