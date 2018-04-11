using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject cubePrefab;
    public int numberOfCubes;
    public float firstCubePosition; //The position of the cube with the lowest x-value
    public float spacing; //Distance between the cubes, usually same as the cube width
    public Player1Controller player1Controller;
    public Player2Controller player2Controller;   

    // Use this for initialization
    void Start () {
            for (int i = 0; i<numberOfCubes; i++)
        {
            // Create the Bullet from the Bullet Prefab
            var cube = (GameObject)Instantiate(cubePrefab, new Vector3(firstCubePosition + (i * spacing), 0), new Quaternion());
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Input.mousePosition.y < Screen.height / 2)
            {
                player1Controller.SpawnProjectile();
            }
            if (Input.mousePosition.y > Screen.height / 2)
            { 
                player2Controller.SpawnProjectile();
            }
        }

        Touch[] myTouches = Input.touches;
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                if (Input.mousePosition.y < Screen.height / 2)
                {
                    player1Controller.SpawnProjectile();
                }
                if (Input.mousePosition.y > Screen.height / 2)
                {
                    player2Controller.SpawnProjectile();
                }
            }
        }
    }
}
