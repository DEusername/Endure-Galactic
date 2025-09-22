using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrientToMouse : MonoBehaviour
{
    public Camera mainCamera; // Assign your main camera reference in the Inspector

    private bool timeToRotate = true;

    private void Update()
    {
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; // Ensure the Z coordinate is zero in 2D

        if(timeToRotate)
        {
            Vector3 lookDir = mousePosition - transform.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    public void stopRotate()
    {
        timeToRotate = false;
    }

    public void startRotate()
    {
        timeToRotate = true;
    }
}
