using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControllerMove : MonoBehaviour
{

    public GameController gameController;
    public CameraShake cameraShake;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        gameController.player1Controller.SpawnProjectile();
        gameController.player1Controller.bulletTimer = 0;
        gameController.player2Controller.SpawnProjectile();
        gameController.player2Controller.bulletTimer = 0;

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            gameController.BackToMenu();
            return;
        }

        if (!gameController.gameOver)
        {
            if (Input.GetMouseButtonUp(0))
            {
                gameController.player1Controller.direction = 0f;
                gameController.player2Controller.direction = 0f;
            }

            //Mouse Controls
            if (Input.GetMouseButtonDown(0))
            {
                if (Input.mousePosition.y < Screen.height / 2 && Input.mousePosition.x > Screen.width / 2)
                {
                    gameController.player1Controller.direction = 1f;
                }
                if (Input.mousePosition.y < Screen.height / 2 && Input.mousePosition.x < Screen.width / 2)
                {
                    gameController.player1Controller.direction = -1f;
                }
                if (Input.mousePosition.y > Screen.height / 2 && Input.mousePosition.x < Screen.width / 2)
                {
                    gameController.player2Controller.direction = -1f;
                }
                if (Input.mousePosition.y > Screen.height / 2 && Input.mousePosition.x > Screen.width / 2)
                {
                    gameController.player2Controller.direction = 1f;
                }
            }



            //Touch Controls
            Touch[] myTouches = Input.touches;
            if (Input.touchCount > 0)
            {
                for (int i = 0; i < Input.touchCount; i++)
                {
                    if (myTouches[i].position.y < Screen.height / 2 && Input.mousePosition.x > Screen.width / 2)
                    {

                        gameController.player1Controller.direction = 1f;

                    }
                    if (myTouches[i].position.y < Screen.height / 2 && Input.mousePosition.x < Screen.width / 2)
                    {

                        gameController.player1Controller.direction = -1f;

                    }
                    if (myTouches[i].position.y > Screen.height / 2 && Input.mousePosition.x > Screen.width / 2)
                    {

                        gameController.player2Controller.direction = 1f;

                    }
                    if (myTouches[i].position.y > Screen.height / 2 && Input.mousePosition.x < Screen.width / 2)
                    {

                        gameController.player2Controller.direction = -1f;

                    }
                }
            }
            else if(Input.touchCount == 0)
            {

                gameController.player1Controller.direction = 0f;
                gameController.player2Controller.direction = 0f;

            }
        }
    }
}
