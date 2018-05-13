using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PlayerController : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Button overchargeButton;
    public Transform bulletSpawn;
    public Transform heatMeter;
    public float projectileSpeed = 10f;
    public float shipSpeed = 5f;
    public float distance = 9f;
    Vector3 speed;
    
    public float defaultBulletDelay = 0.5f;
    public float overchargeBulletDelay = 0.1f;
    public float overchargeCooldown = 10.0f;
    public float overchargeDuration = 2.0f;

    public AudioClip shoot;
    public AudioClip overcharge;
    private AudioSource source;

    public float bulletDelay;
    public float bulletTimer;
    float overchargeTimer;
    public float direction = 0f;
    
    //shield
    public Button shieldButton;
    public float shieldDuration = 5.0f;
    float shieldTimer;
    public float shieldCooldown = 10.0f;
    public GameObject shield;
    public Boolean shieldIsActive;

    //Opposite control
    public Button oppositeButton;
    public float oppositeDuration = 3.0f;
    float oppositeTimer;
    public float oppositeCooldown = 10.0f;
    public GameObject opposite;
    public Boolean oppositeIsActive;

    // Use this for initialization
    void Start()
    {
        shield.SetActive(false);
        shieldIsActive = false;
        shieldTimer = shieldCooldown;
        overchargeTimer = overchargeCooldown;
        bulletDelay = defaultBulletDelay;
        opposite.SetActive(false);
        oppositeIsActive = false;
        oppositeTimer = oppositeCooldown;
    }

    public void SpawnProjectile()
    {
        // Create the Bullet from the Bullet Prefab
        var bullet = (GameObject)Instantiate(projectilePrefab, bulletSpawn.position, bulletSpawn.rotation);

        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = bulletSpawn.transform.up * projectileSpeed;

        source = GetComponent<AudioSource>();

        //Play sound
        source.PlayOneShot(shoot);

        // Destroy the bullet after 5 seconds
        Destroy(bullet, 5.0f);
    }

    internal void MoveRight()
    {
        if (speed.x < 10)
        {
            speed += new Vector3(4, 0);
        }
    }

    internal void MoveLeft()
    {
        if (speed.x > -10)
        {
            speed += new Vector3(-4, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        bulletTimer += Time.deltaTime;

        if (bulletTimer > bulletDelay)
        {
            SpawnProjectile();
            bulletTimer = 0f;
        }


        //Stop the ship from going out of bounds
        if(transform.position.x < -distance)
        {
            transform.position = new Vector3(distance, transform.position.y);
        }

        if (transform.position.x > distance)
        {
            transform.position = new Vector3(distance, transform.position.y);
        }

        //Move ship
        transform.position += speed * Time.deltaTime;

        //Make the ship stop if there's no input
        Stop();

        //Handle overcharge
        overchargeTimer += Time.deltaTime;

        if(overchargeTimer > overchargeDuration)
        {
            bulletDelay = defaultBulletDelay;
        }

        if(overchargeTimer > overchargeCooldown)
        {
            overchargeButton.interactable = true;
        }

        //Handle shield
        shieldTimer += Time.deltaTime;

        if(shieldTimer > shieldDuration)
        {
            shield.SetActive(false);
            shieldIsActive = false;
        }

        if(shieldTimer > shieldCooldown)
        {
            shieldButton.interactable = true;
        }

        //Handle opposite
        oppositeTimer += Time.deltaTime;

        if(oppositeTimer > oppositeDuration)
        {
            opposite.SetActive(false);
            oppositeIsActive = false;
        }

        if(oppositeTimer > oppositeCooldown)
        {
            oppositeButton.interactable = true;
        }
    }

    internal void PowerUp(int powerupNumber)
    {
        if(powerupNumber == 1)
        {
            Overcharge();
        }
    }

    public void Overcharge()
    {
        if (overchargeTimer > overchargeCooldown)
        {
            bulletDelay = overchargeBulletDelay;
            overchargeTimer = 0f;
            overchargeButton.interactable = false;
            source = GetComponent<AudioSource>();
            source.PlayOneShot(overcharge);
        }
    }

    public void Stop()
    {
        if (speed.x > 0)
        {
            speed += new Vector3(-2, 0);
        }
        if (speed.x < 0)
        {
            speed += new Vector3(2, 0);
        }
    }

    //Shield
    public void Shield()
    {
        if(shieldTimer > shieldCooldown)
        {
            shield.SetActive(true);
            shieldIsActive = true;
            shieldButton.interactable = false;
            shieldTimer = 0f;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Cube")
        {
            if (shieldIsActive)
            {
                shield.SetActive(false);
                shieldIsActive = false;
                shieldTimer = 5.1f;
                GetComponent<PlayerMovement>().health
            }
        }
    }
    //Opposite
    public void Opposite()
    {
        if (oppositeTimer > oppositeCooldown)
        {
            opposite.SetActive(true);
            oppositeIsActive = true;
            oppositeButton.interactable = false;
            oppositeTimer = 0f;
        }
    }
}
