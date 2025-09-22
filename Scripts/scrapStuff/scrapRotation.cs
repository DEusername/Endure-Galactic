using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrapRotation : MonoBehaviour
{
    public float rotationSpeed = 30f; // Adjust this value to set the rotation speed in degrees per second

    private void Update()
    {
        // Rotate the object around its Z-axis at the specified speed
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
