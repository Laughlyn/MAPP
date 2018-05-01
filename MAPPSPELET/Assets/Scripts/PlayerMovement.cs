using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float damageTimer;
    private float damageTimer2;
    public int health = 3;
    public int health2 = 3;

    // Use this for initialization
    void Start ()
    {
        health = 3;
        health2 = 3;
	}
	
	// Update is called once per frame
	void Update ()
    {
        damageTimer += Time.deltaTime;
        damageTimer2 += Time.deltaTime;
    }

    public void Harm(int dmg)
    {
        if (damageTimer > 1.0f)
        {
            health -= dmg;
            damageTimer = 0;
            if(health == 2)
            {
                GameController.GameControllerInstance.heart3.SetActive(false);
            }
            if(health == 1)
            {
                GameController.GameControllerInstance.heart2.SetActive(false);
            }
            if(health < 1)
            {
                GameController.GameControllerInstance.heart1.SetActive(false);
                Debug.Log("DÖÖ");
                GameController.GameControllerInstance.restart.SetActive(true);
                GameController.GameControllerInstance.gameOver = true;
            }
        }
    }
    public void Harm2(int dmg)
    {
        if (damageTimer2 > 1.0f)
        {
            health2 -= dmg;
            damageTimer2 = 0;
            if (health2 == 2)
            {
                GameController.GameControllerInstance.heart4.SetActive(false);
            }
            if (health2 == 1)
            {
                GameController.GameControllerInstance.heart5.SetActive(false);
            }
            if (health2 < 1)
            {
                GameController.GameControllerInstance.heart6.SetActive(false);
                Debug.Log("DÖÖ");
                GameController.GameControllerInstance.restart.SetActive(true);
                GameController.GameControllerInstance.gameOver = true;
            }
        }
    }
}
