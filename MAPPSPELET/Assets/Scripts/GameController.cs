﻿using System.Collections;
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

    public GameObject restart;
    public bool gameOver;
    public GameObject menuPanel;

    public GameObject player1;
    public GameObject player2;

    public GameObject player1Pic;
    public GameObject player2Pic;

    public Sprite player1Sprite;
    public Sprite player2Sprite;

    // Use this for initialization
    void Start ()
	{
        GameControllerInstance = this;
        gameOver = false;

        //Create a row of cubes
        CreateCubes();
        ResetHearts();
        ResetHealth();
        ResetSprites();

        restart.SetActive(false);

        player1Pic.SetActive(false);
        player2Pic.SetActive(false);

	}
	
	// Update is called once per frame
	void Update ()
    {
        if (player1.GetComponent<PlayerMovement>().winner == 1 || player2.GetComponent<PlayerMovement>().winner == 1)
        {
            player1Pic.SetActive(true);
        }else if(player1.GetComponent<PlayerMovement>().winner == 2 || player2.GetComponent<PlayerMovement>().winner == 2)
        {
            player2Pic.SetActive(true);
        }
    }

    public void RestartGame()
    {
        GameControllerInstance = this;

        player1Controller.bulletTimer = 3.0f;
        player2Controller.bulletTimer = 3.0f;

        RemoveCubes();
        CreateCubes();
        ResetHealth();
        ResetHearts();
        ResetSprites();

        player1.GetComponent<PlayerMovement>().winner = 0;
        player2.GetComponent<PlayerMovement>().winner = 0;
        player1Pic.SetActive(false);
        player2Pic.SetActive(false);

        
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
        player1.GetComponent<PlayerMovement>().heart1.SetActive(true);
        player1.GetComponent<PlayerMovement>().heart2.SetActive(true);
        player1.GetComponent<PlayerMovement>().heart3.SetActive(true);
        player2.GetComponent<PlayerMovement>().heart1.SetActive(true);
        player2.GetComponent<PlayerMovement>().heart2.SetActive(true);
        player2.GetComponent<PlayerMovement>().heart3.SetActive(true);
    }
    void ResetHealth()
    {
        player1.GetComponent<PlayerMovement>().health = 3;
        player2.GetComponent<PlayerMovement>().health = 3;
    }

    void ResetSprites()
    {
        player1.GetComponent<SpriteRenderer>().sprite = player1Sprite;
        player2.GetComponent<SpriteRenderer>().sprite = player2Sprite;
    }
}
