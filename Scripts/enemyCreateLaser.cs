using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyCreateLaser : MonoBehaviour
{
    public GameObject laserPrefab;
    public float fireRate = 0.15f; // Adjust this value to set the time delay between bullet spawns

    private bool canFire = true;
    private GameObject spawnedLaser;

    // Update is called once per frame
    void Update()
    {
        if (canFire)
        {
            SpawnLaser();
            StartCoroutine(FireCooldown());
        }
        spawnedLaser.transform.position = transform.position;
    }

    void SpawnLaser()
    {
        spawnedLaser = Instantiate(laserPrefab, transform.position, Quaternion.identity);
        spawnedLaser.transform.rotation = transform.rotation;

        StartCoroutine(DestroyLaser(spawnedLaser));
    }

    IEnumerator FireCooldown()
    {
        canFire = false;
        yield return new WaitForSeconds(fireRate);
        canFire = true;
    }

    IEnumerator DestroyLaser(GameObject laserPassedIn)
    {
        yield return new WaitForSeconds(5);
        Destroy(laserPassedIn);
    }
}
