using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createMissile : MonoBehaviour
{
    public GameObject missilePrefab;
    public Transform missileSpawnPoint; // Assign the empty GameObject as the spawn point in the Inspector
    public float fireRate = 0.15f; // Adjust this value to set the time delay between bullet spawns

    private bool canFire = true;
    private bool stopMidCoroutineFlag = false;

    void Update()
    {
        if (Input.GetKey(KeyCode.X) && Time.timeScale != 0f)
        {
            if(canFire)
            {
                ShootBullet();
                StartCoroutine(FireCooldown());
            }
        }
    }

    void ShootBullet()
    {
        // Instantiate the bullet prefab at the current position of the shooting object (usually the player)
        GameObject newBullet = Instantiate(missilePrefab, transform.position, Quaternion.identity);

        newBullet.transform.rotation = transform.rotation;
    }

    IEnumerator FireCooldown()
    {
        canFire = false;
        yield return new WaitForSeconds(fireRate);
        if (!stopMidCoroutineFlag)
        {
            canFire = true;
        }
    }

    public void startShoot()
    {
        canFire = true;
        stopMidCoroutineFlag = false;
    }

    public void stopShoot()
    {
        canFire = false;
        stopMidCoroutineFlag = true;
    }
}
