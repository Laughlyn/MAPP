using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float damageTimer;
    public int health = 3;
    public GameObject heart1, heart2, heart3;
    public int winner;

    public CameraShake cameraShake;
    public AudioClip harm;
    private AudioSource source;
    public Sprite damagedSprites;

    public ParticleSystem explosion;
    public ParticleSystem debris;

    public float destroyTimer = 0.0f;

    // Use this for initialization
    void Start ()
    {
        health = 3;
        winner = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
        damageTimer += Time.deltaTime;
        if (health == 2)
        {
            heart3.SetActive(false);
            this.GetComponent<SpriteRenderer>().sprite = damagedSprites;
        }
        if (health == 1)
        {
            heart2.SetActive(false);
        }
        if (health < 1)
        {
            destroyTimer += Time.deltaTime;
            heart1.SetActive(false);
            Debug.Log("DÖÖ");
            GameController.GameControllerInstance.restart.SetActive(true);
            GameController.GameControllerInstance.gameOver = true;
            if (!explosion.isPlaying)
            {
                explosion.Play();
            }
            if (!debris.isPlaying)
            {
                debris.Play();
                
            }
            if(destroyTimer > 2f)
            {
                this.GetComponent<SpriteRenderer>().sprite = null;
            }

            if (this.gameObject.CompareTag("Player1"))
            {
                Debug.Log("Player1");
                winner = 2;
            }
            else if (this.gameObject.CompareTag("Player2"))
            {
                Debug.Log("Player2");
                winner = 1;
            }
        }
    }

    public void Harm(int dmg)
    {
        if (damageTimer > 1.0f)
        {
                health -= dmg;
                damageTimer = 0;

            if (this.GetComponent<PlayerController>().shieldTimer > 5.2f)
            {
                StartCoroutine(cameraShake.Shake(.15f, 4f));
            }
                source = GetComponent<AudioSource>();

                //Play sound
                source.PlayOneShot(harm);
        }
    }
}
