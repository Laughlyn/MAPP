using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerController : MonoBehaviour
{

    public GameObject projectilePrefab;
    public Transform bulletSpawn;
    public int projectileSpeed = 5;

    // Use this for initialization
    void Start()
    {

    }

    public void SpawnProjectile()
    {
        // Create the Bullet from the Bullet Prefab
        var bullet = (GameObject)Instantiate(projectilePrefab, bulletSpawn.position, bulletSpawn.rotation);

        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = bulletSpawn.transform.up * projectileSpeed;

        // Destroy the bullet after 5 seconds
        Destroy(bullet, 5.0f);

    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
