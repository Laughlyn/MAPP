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

    public float bulletDelay = 0.3f;

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

        heart1.SetActive(true);
        heart2.SetActive(true);
        heart3.SetActive(true);
        heart4.SetActive(true);
        heart5.SetActive(true);
        heart6.SetActive(true);

        restart.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }
        

        bulletTimer1 += Time.deltaTime;
        bulletTimer2 += Time.deltaTime;

        if (!gameOver)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (Input.mousePosition.y < Screen.height / 2 && bulletTimer1 > bulletDelay)
                {
                    player1Controller.SpawnProjectile();
                    bulletTimer1 = 0;
                }
                if (Input.mousePosition.y > Screen.height / 2 && bulletTimer2 > bulletDelay)
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
                    if (myTouches[i].position.y < Screen.height / 2 && bulletTimer1 > bulletDelay)
                    {
                        player1Controller.SpawnProjectile();
                        bulletTimer1 = 0;
                    }
                    if (myTouches[i].position.y > Screen.height / 2 && bulletTimer2 > bulletDelay)
                    {
                        player2Controller.SpawnProjectile();
                        bulletTimer2 = 0;
                    }
                }
            }
        }
    }

    public void RestartGame()
    {
        GameControllerInstance = this;

        bulletTimer1 = 3.0f;
        bulletTimer2 = 3.0f;

        CreateCubes();

        heart1.SetActive(true);
        heart2.SetActive(true);
        heart3.SetActive(true);
        heart4.SetActive(true);
        heart5.SetActive(true);
        heart6.SetActive(true);
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
}
