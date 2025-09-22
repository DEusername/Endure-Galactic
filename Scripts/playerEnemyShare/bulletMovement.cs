using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMovement : MonoBehaviour
{
    public float speed = 10f; // Adjust this value to control the bullet speed

    void Update()
    {
        // Move the bullet forward along its local right direction (assuming the bullet sprite is facing right)
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("BulletCollided");
    }
}
