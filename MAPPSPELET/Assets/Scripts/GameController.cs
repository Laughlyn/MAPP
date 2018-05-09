using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    float bulletTimer1;
    float bulletTimer2;

    public GameObject heart1, heart2, heart3, heart4, heart5, heart6;

    public GameObject restart;
    public bool gameOver;
    public GameObject menuPanel;

    // Use this for initialization
    void Start ()
	{
        GameControllerInstance = this;
        gameOver = false;
        bulletTimer1 = 3.0f;
        bulletTimer2 = 3.0f;

        //Create a row of cubes

        CreateCubes();
        ResetHearts();

        restart.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
    {

    }

    public void RestartGame()
    {
        GameControllerInstance = this;

        player1Controller.bulletTimer = 3.0f;
        player2Controller.bulletTimer = 3.0f;

        RemoveCubes();
        CreateCubes();
        ResetHearts();
        
        restart.SetActive(false);
        gameOver = false;
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    void CreateCubes()
    {
        GameObject cube = null;
        GameObject previousCube = null;

        //Create a row of cubes
        for (int i = 0; i < numberOfCubes; i++)
        {
            previousCube = cube;
            cube = (GameObject)Instantiate(cubePrefab, new Vector3(firstCubePosition + (i * spacing), 0), new Quaternion());
            cube.GetComponent<CubeController>().previousCube = previousCube;

            if (previousCube != null)
            {
                previousCube.GetComponent<CubeController>().nextCube = cube;
            }
        }
    }

    void RemoveCubes()
    {
        GameObject[] list = GameObject.FindGameObjectsWithTag("Cube");

        foreach (var cube in list)
        {
            Destroy(cube);
        }
    }

    void ResetHearts()
    {
        heart1.SetActive(true);
        heart2.SetActive(true);
        heart3.SetActive(true);
        heart4.SetActive(true);
        heart5.SetActive(true);
        heart6.SetActive(true);
    }
}
