using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaScript : MonoBehaviour
{

    

	// Use this for initialization
	void Start ()
    {
       
    }
	
	// Update is called once per frame
	void Update ()
    {
        Color cubeColor;
        cubeColor = GetComponent<SpriteRenderer>().color;
        if (cubeColor.a > 0)
        {
            cubeColor.a -= (.5f + cubeColor.a) * Time.deltaTime;
        }
        GetComponent<SpriteRenderer>().color = cubeColor;
    }
}
