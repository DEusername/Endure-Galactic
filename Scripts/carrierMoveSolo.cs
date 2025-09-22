using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carrierMoveSolo : MonoBehaviour
{
    public float forwardSpeed = 1.0f; // Adjust as needed
    public float rotationSpeed = 5.0f; // Adjust as needed

    private void Update()
    {
        // Handle forward movement
        Vector3 forwardDirection = transform.up; // Adjust for your desired forward direction
        transform.Translate(forwardDirection * forwardSpeed * Time.deltaTime, Space.World);

        // Handle rotation
        float rotationInput = 1.0f; // You can replace this with your control input
        float rotationAmount = rotationInput * rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.forward * rotationAmount);
    }
}
