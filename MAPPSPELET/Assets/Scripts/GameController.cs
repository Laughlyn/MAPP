using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject cubePrefab;
    public int numberOfCubes;
    public float firstCubePosition; //The position of the cube with the lowest x-value
    public float spacing; //Distance between the cubes, usually same as the cube width

    // Use this for initialization
    void Start () {
            for (int i = 0; i<numberOfCubes; i++)
        {
            // Create the Bullet from the Bullet Prefab
            var cube = (GameObject)Instantiate(cubePrefab, new Vector3(firstCubePosition + (i * spacing), 0), new Quaternion());
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
