using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : MonoBehaviour {

    public GameObject projectilePrefab;
    public Transform bulletSpawn;
    public int speed;

    // Use this for initialization
    void Start()
    {

    }

    public void SpawnProjectile()
    {
        // Create the Bullet from the Bullet Prefab
        var bullet = (GameObject)Instantiate(projectilePrefab, bulletSpawn.position, bulletSpawn.rotation);

        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = bulletSpawn.transform.up * speed;

        // Destroy the bullet after 5 seconds
        Destroy(bullet, 5.0f);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Input.mousePosition.y < 1000)
            {
                SpawnProjectile();
            }
        }
    }
}
