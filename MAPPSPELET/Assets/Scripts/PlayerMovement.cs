using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float direction = 1f;
    public float speed = 1f;
    public float distance = 2.3f;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        
        if (transform.position.x > distance || transform.position.x < -distance)
        {
            direction *= -1;
        }
        transform.Translate(Time.deltaTime*direction*speed, 0, 0, Space.World);
    }
}
