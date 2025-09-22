using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraZoom : MonoBehaviour
{
    public float zoomSpeed = 1f; // Adjust this value to control the zoom speed
    public float minZoom = 3f; // Adjust this value to set the minimum orthographic size (zoom in limit)
    public float maxZoom = 10f; // Adjust this value to set the maximum orthographic size (zoom out limit)
    public float startingOrthoSize = 5f; // Adjust this value to set the initial orthographic size
    public bool canZoom = true;

    void Start()
    {
        // Set the initial orthographic size of the camera
        Camera.main.orthographicSize = startingOrthoSize;
    }

    void Update()
    {
        if (canZoom)
        {
            // Get the mouse scroll wheel input to zoom in and out
            float scrollValue = Input.GetAxis("Mouse ScrollWheel");

            // Calculate the new orthographic size
            float newOrthoSize = Camera.main.orthographicSize - scrollValue * zoomSpeed;

            // Clamp the new orthographic size to the specified zoom limits
            newOrthoSize = Mathf.Clamp(newOrthoSize, minZoom, maxZoom);

            // Apply the new orthographic size to the camera
            Camera.main.orthographicSize = newOrthoSize;
        }
    }

    public void notOkToZoom()
    {
        canZoom = false;
    }

    public void okToZoom()
    {
        canZoom = true;
    }
}
