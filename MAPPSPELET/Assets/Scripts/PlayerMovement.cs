using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float direction = 1f;
    public float speed = 1f;
    public float distance = 2.3f;

    private float damageTimer;
    public int health = 3;

    // Use this for initialization
    void Start ()
    {
        health = 3;	
	}
	
	// Update is called once per frame
	void Update ()
    {
        
        if (transform.position.x > distance || transform.position.x < -distance)
        {
            direction *= -1;
        }
        transform.Translate(Time.deltaTime*direction*speed, 0, 0, Space.World);

        damageTimer += Time.deltaTime;
        GameController.GameControllerInstance.playerHealth = health;

    }

    public void Harm(int dmg)
    {
        if (damageTimer > 1.0f)
        {
            health -= dmg;
            damageTimer = 0;
            if(health < 1)
            {
                Debug.Log("DÖÖ");
            }
        }
    }
}
