using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float damageTimer;
    public int health = 3;
    public GameObject heart1, heart2, heart3;

    public CameraShake cameraShake;
    public AudioClip harm;
    private AudioSource source;

    // Use this for initialization
    void Start ()
    {
        health = 3;
	}
	
	// Update is called once per frame
	void Update ()
    {
        damageTimer += Time.deltaTime;
        if (health == 2)
        {
            heart3.SetActive(false);
        }
        if (health == 1)
        {
            heart2.SetActive(false);
        }
        if (health < 1)
        {
            heart1.SetActive(false);
            Debug.Log("DÖÖ");
            GameController.GameControllerInstance.restart.SetActive(true);
            GameController.GameControllerInstance.gameOver = true;
        }
    }

    public void Harm(int dmg)
    {
        if (damageTimer > 1.0f)
        {
                health -= dmg;
                damageTimer = 0;
                
                StartCoroutine(cameraShake.Shake(.15f, 4f));

                source = GetComponent<AudioSource>();

                //Play sound
                source.PlayOneShot(harm);
        }
    }
}
