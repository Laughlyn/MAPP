using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float direction = 1f;
    public float speed = 1f;
    public float distance = 2.3f;
    bool goingLeft = false;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Change direction
        if (transform.position.x > distance)
        {
            if (!goingLeft)
            {
                direction *= -1f;
                goingLeft = true;
            }
        }
        if(transform.position.x < -distance)
        {
            if (goingLeft)
            {
                direction *= -1f;
                goingLeft = false;
            }
        }

        // Move the block
        transform.Translate(Time.deltaTime * direction * speed, 0, 0, Space.World);
    }
}
