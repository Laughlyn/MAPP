using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Projectile" || other.gameObject.tag == "Player1" || other.gameObject.tag == "Player2")
        {
            return;
        }
        Destroy(gameObject);
    }

}
