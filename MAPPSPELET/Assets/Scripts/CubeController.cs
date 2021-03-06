﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CubeController: MonoBehaviour
{
    public bool chain = true;

    public Material material;
    public int hitLimit;
    int hitCounter;

    public float hitDistance;
    public Vector3 destinationMax;
    public Vector3 hitVector = new Vector3(0 , 5.0f);
	public GameObject previousCube;
	public GameObject nextCube;

    public AudioClip impact;
    private AudioSource source;

    Vector3 destination;
    Vector3 resetVector;

    Material CubeMaterial;
    Color CubeColor;

    float randomValue;

    public GameObject player1;
    public GameObject player2;

    // Use this for initialization
    void Start ()
	{
        destination = transform.position;
        resetVector.x = transform.position.x;

        //randomValue = Random.value;

        //hitVector = new Vector3(0, randomValue * 10);

        ////Random color for blocks
        //CubeMaterial = GetComponent<Renderer>().material;
        //CubeColor = new Color(randomValue, randomValue, randomValue);
        //CubeMaterial.SetColor("_Color", CubeColor);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(transform.position != destination)
        {
            transform.position += (destination - transform.position) * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            if (!GameController.GameControllerInstance.gameOver)
            {
                if (other.GetComponent<Rigidbody>().velocity.y > 0)
                {
                    hitCounter++;
                    destination += hitVector;
                    destination.y = Mathf.Clamp(destination.y, -destinationMax.y, destinationMax.y);
                    Component[] spriteRenderers;

                    spriteRenderers = GetComponentsInChildren<SpriteRenderer>();

                    foreach (SpriteRenderer spriteRenderer in spriteRenderers)
                    {
                        if (spriteRenderer.gameObject.CompareTag("ImpactBottom"))
                        {
                            Color color = spriteRenderer.color;
                            color.a = 1f;
                            spriteRenderer.gameObject.GetComponent<SpriteRenderer>().color = color;
                        }
                    }
                }
                if (other.GetComponent<Rigidbody>().velocity.y < 0)
                {
                    hitCounter--;
                    destination -= hitVector;
                    destination.y = Mathf.Clamp(destination.y, -destinationMax.y, destinationMax.y);
                    Component[] spriteRenderers;

                    spriteRenderers = GetComponentsInChildren<SpriteRenderer>();

                    foreach (SpriteRenderer spriteRenderer in spriteRenderers)
                    {
                        if (spriteRenderer.gameObject.CompareTag("ImpactTop"))
                        {
                            Color color = spriteRenderer.color;
                            color.a = 1f;
                            spriteRenderer.gameObject.GetComponent<SpriteRenderer>().color = color;
                        }
                    }
                }

                source = GetComponent<AudioSource>();
                source.pitch = Random.Range(.3f, .7f);
                source.PlayOneShot(impact);
                Destroy(other.gameObject);
            }
        }

        if (other.gameObject.tag == "Player1")
        {
            if (!player1.GetComponent<PlayerController>().shieldIsActive)
            {
                other.GetComponent<PlayerMovement>().Harm(1);
                destination = resetVector;
            }
        }
        if (other.gameObject.tag == "Player2")
        {
            if (!player2.GetComponent<PlayerController>().shieldIsActive)
            {
                other.GetComponent<PlayerMovement>().Harm(1);
                destination = resetVector;
            }
        }
    }
}
