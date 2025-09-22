using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserDealDamage : MonoBehaviour
{
    public int damageAmount = 50;

    private bool alreadyDealtDamage = false;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            healthSystem healthSystem = other.GetComponent<healthSystem>();
            if (healthSystem != null)
            {
                SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
                if(spriteRenderer != null)
                {
                    if(spriteRenderer.color.a >= 0.95f)
                    {
                        if (!alreadyDealtDamage)
                        {
                            healthSystem.TakeDamage(damageAmount);
                            alreadyDealtDamage = true;
                        }
                    }
                }
            }
        }
    }
}
