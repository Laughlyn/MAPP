using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameController : MonoBehaviour
{

    public GameObject cubePrefab;
    public int numberOfCubes;
    public float firstCubePosition; //The position of the cube with the lowest x-value
    public float spacing; //Distance between the cubes, usually same as the cube width
    public PlayerController player1Controller;
    public PlayerController player2Controller;


    // Use this for initialization
    void Start ()
	{
		GameObject cube = null;
		GameObject previousCube = null;

		//Create a row of cubes
        for (int i = 0; i < numberOfCubes; i++)
        {
			previousCube = cube;
    		cube = (GameObject)Instantiate(cubePrefab, new Vector3(firstCubePosition + (i * spacing), 0), new Quaternion());
			cube.GetComponent<CubeController> ().previousCube = previousCube;

			if (previousCube != null)
			{
				previousCube.GetComponent<CubeController> ().nextCube = cube;
			}

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
				if (myTouches[i].position.y < Screen.height / 2)
                {
                    player1Controller.SpawnProjectile();
                }
				if (myTouches[i].position.y > Screen.height / 2)
                {
                    player2Controller.SpawnProjectile();
                }
            }
		}
    }
}
