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
    
    public float defaultBulletDelay = 0.3f;
    public float overchargeBulletDelay = 0.1f;
    public float overchargeCooldown = 10.0f;
    public float overchargeDuration = 2.0f;

    public AudioClip shoot;
    public AudioClip overcharge;
    private AudioSource source;

    public float bulletDelay;
    float timer;
    float direction = 1f;

    public float heatMax = 100f;
    public float heatPerShot = 5f;
    float heat;

    // Use this for initialization
    void Start()
    {
        timer = overchargeCooldown;
        bulletDelay = defaultBulletDelay;
    }

    public void SpawnProjectile()
    {
        if (heat > heatMax)
        {
            return;
        }

        // Create the Bullet from the Bullet Prefab
        var bullet = (GameObject)Instantiate(projectilePrefab, bulletSpawn.position, bulletSpawn.rotation);

        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = bulletSpawn.transform.up * projectileSpeed;

        source = GetComponent<AudioSource>();

        //Play sound
        source.PlayOneShot(shoot);

        //Increase heat
        heat += heatPerShot;

        // Destroy the bullet after 5 seconds
        Destroy(bullet, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > distance && direction > 0)
        {
            direction *= -1;
        }
        else if (transform.position.x < -distance && direction < 0)
        {
            direction *= -1;
        }
        transform.Translate(Time.deltaTime * direction * shipSpeed, 0, 0, Space.World);

        timer += Time.deltaTime;

        if(timer > overchargeDuration)
        {
            bulletDelay = defaultBulletDelay;
        }
        if(timer > overchargeCooldown)
        {
            overchargeButton.interactable = true;
        }

        if (heat > 0)
        {
            heat -= Time.deltaTime * 10;
        }

        heatMeter.GetComponent<SpriteRenderer>().color = new Color(1, 1 - (heat / 100), 1 - (heat / 100)); 
    }

    public void Overcharge()
    {
        if (timer > overchargeCooldown)
        {
            bulletDelay = overchargeBulletDelay;
            timer = 0f;
            overchargeButton.interactable = false;
            source = GetComponent<AudioSource>();
            source.PlayOneShot(overcharge);
        }
    }
}
