using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyCreateBullet : MonoBehaviour
{
    public GameObject muzzleFlash;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint; // Assign the empty GameObject as the spawn point in the Inspector
    public float fireRate = 0.15f; // Adjust this value to set the time delay between bullet spawns

    private bool canFire = true;

    // Update is called once per frame
    void Update()
    {
        if (canFire)
        {
            ShootBullet();
            Instantiate(muzzleFlash, transform.position, Quaternion.identity);
            StartCoroutine(FireCooldown());
        }
    }

    void ShootBullet()
    {
        // Instantiate the bullet prefab at the current position of the shooting object (usually the player)
        GameObject newBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        // Optionally, you can set the direction of the bullet (for example, if you want the bullet to follow the player's facing direction)
        // You can do this by setting the rotation of the bullet to match the player's rotation:
        newBullet.transform.rotation = transform.rotation;
    }

    IEnumerator FireCooldown()
    {
        canFire = false;
        yield return new WaitForSeconds(fireRate);
        canFire = true;
    }
}
