using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orbitMovement : MonoBehaviour
{
    public Transform centerPoint; // Reference to the center point of the orbit
    public float orbitRadius = 8f; // Adjust this value to set the radius of the orbit
    public float orbitSpeed = 0.5f; // Adjust this value to control the speed of the orbit

    private Vector3 previousPosition;

    void Start()
    {
        // Calculate the initial position of the carrier on the orbit circle
        Vector3 initialOffset = new Vector3(Mathf.Cos(0f), Mathf.Sin(0f), 0f) * orbitRadius;
        transform.position = centerPoint.position + initialOffset;

        // Move the carrier one step forward in the orbit to establish the correct facing direction
        Vector3 nextOffset = new Vector3(Mathf.Cos(orbitSpeed * Time.deltaTime), Mathf.Sin(orbitSpeed * Time.deltaTime), 0f) * orbitRadius;
        transform.position = centerPoint.position + nextOffset;

        previousPosition = transform.position;
    }

    void Update()
    {
        // Calculate the new position of the carrier based on the current angle of rotation
        Vector3 offset = new Vector3(Mathf.Cos(Time.time * orbitSpeed), Mathf.Sin(Time.time * orbitSpeed), 0f) * orbitRadius;
        transform.position = centerPoint.position + offset;

        Debug.Log("transform Position" + transform.position);

        // Update the rotation of the carrier to face the direction of movement
        Vector3 currentVelocity = (transform.position - previousPosition).normalized;
        if (currentVelocity != Vector3.zero)
        {
            transform.up = currentVelocity; // Reverse the direction to face the correct way
        }

        previousPosition = transform.position;
    }
}
