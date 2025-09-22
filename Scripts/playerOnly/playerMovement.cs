using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust this value to control the character's speed

    private Rigidbody2D rb;
    public static playerMovement playerInstance;
    private bool fastMode = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInstance = this;
    }

    private void Update()
    {
        if (!fastMode)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector2 movement = new Vector2(horizontalInput, verticalInput);
            movement.Normalize(); // Normalize the vector to prevent faster diagonal movement

            rb.velocity = movement * moveSpeed;
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
            // Move the object forward based on its local forward direction
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        }
    }

    public void FastModeSetTrue()
    {
        moveSpeed = moveSpeed * 2f;
        fastMode = true;
    }

    public void FastModeSetFalse()
    {
        moveSpeed = moveSpeed / 2f;
        fastMode = false;
    }
}
