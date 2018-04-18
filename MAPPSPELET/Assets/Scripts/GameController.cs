using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class GameController : MonoBehaviour
{
    public static GameController GameControllerInstance;

    public GameObject cubePrefab;
    public int numberOfCubes;
    public float firstCubePosition; //The position of the cube with the lowest x-value
    public float spacing; //Distance between the cubes, usually same as the cube width
    public PlayerController player1Controller;
    public PlayerController player2Controller;

    public float bulletTimer1;
    public float bulletTimer2;


    public Slider healthSlider;
    public int playerHealth = 3;

    // Use this for initialization
    void Start ()
	{
		GameObject cube = null;
		GameObject previousCube = null;
        GameControllerInstance = this;

        bulletTimer1 = 3.0f;
        bulletTimer2 = 3.0f;
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
        bulletTimer1 += Time.deltaTime;
        bulletTimer2 += Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            if (Input.mousePosition.y < Screen.height / 2 && bulletTimer1 > 1.0f)
            {
                player1Controller.SpawnProjectile();
                bulletTimer1 = 0;
            }
            if (Input.mousePosition.y > Screen.height / 2 && bulletTimer2 > 1.0f)
            { 
                
                player2Controller.SpawnProjectile();
                bulletTimer2 = 0;
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

        healthSlider.value = playerHealth;
    }
}
