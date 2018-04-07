using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float direction = 1;
    public float speed = 1;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        
        if (transform.position.x > 2.3 || transform.position.x < -2.3)
        {
            direction *= -1;
        }
        transform.Translate(Time.deltaTime*direction*speed, 0, 0, Space.World);
    }
}
