using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControllerMove : MonoBehaviour
{

    public GameController gameController;
    public CameraShake cameraShake;

    public bool mouseControls = false;

    public GameObject player1;
    public GameObject player2;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            gameController.BackToMenu();
            return;
        }

        if (!gameController.gameOver)
        {
            if (mouseControls)
            {
                if (!Input.GetMouseButtonDown(0))
                {
                    gameController.player1Controller.Stop();
                    gameController.player2Controller.Stop();
                }
                //Mouse Controls
                if (Input.GetMouseButton(0))
                {
                    if (Input.mousePosition.y < Screen.height / 2 && Input.mousePosition.x > Screen.width / 2)
                        {
                        if (!player2.GetComponent<PlayerController>().oppositeIsActive)
                        {
                            gameController.player1Controller.MoveRight();
                        }
                        else
                        {
                            gameController.player1Controller.MoveLeft();
                        }
                    }
                    if (Input.mousePosition.y < Screen.height / 2 && Input.mousePosition.x < Screen.width / 2)
                    {
                        if (!player2.GetComponent<PlayerController>().oppositeIsActive)
                        {
                            gameController.player1Controller.MoveLeft();
                        }
                        else
                        {
                            gameController.player1Controller.MoveRight();
                        }
                    }
                    
                    if (Input.mousePosition.y > Screen.height / 2 && Input.mousePosition.x < Screen.width / 2)
                    {
                        if (!player1.GetComponent<PlayerController>().oppositeIsActive)
                        {
                            gameController.player2Controller.MoveLeft();
                        }
                        else
                        {
                            gameController.player2Controller.MoveRight();
                        }
                    }
                    if (Input.mousePosition.y > Screen.height / 2 && Input.mousePosition.x > Screen.width / 2)
                    {
                        if (!player1.GetComponent<PlayerController>().oppositeIsActive)
                        {
                            gameController.player2Controller.MoveRight();
                        }
                        else
                        {
                            gameController.player2Controller.MoveLeft();
                        }
                    }
                }
            }

            //Touch Controls
            /*Touch[] myTouches = Input.touches;
            if (Input.touchCount > 0)
            {
                for (int i = 0; i < Input.touchCount; i++)
                {
                    if (myTouches[i].position.y < Screen.height / 2)
                    {
                        if (myTouches[i].position.y < 100)
                        {
                            gameController.player1Controller.PowerUp(1);
                        }
                        else
                        {
                            if (!player2.GetComponent<PlayerController>().oppositeIsActive)
                            {
                                if (myTouches[i].position.x > Screen.width / 2)
                                {
                                    gameController.player1Controller.MoveRight();
                                }
                                if (myTouches[i].position.x < Screen.width / 2)
                                {
                                    gameController.player1Controller.MoveLeft();
                                }
                            }else if (player2.GetComponent<PlayerController>().oppositeIsActive)
                            {
                                if (myTouches[i].position.x > Screen.width / 2)
                                {
                                    gameController.player1Controller.MoveLeft();
                                }
                                if (myTouches[i].position.x < Screen.width / 2)
                                {
                                    gameController.player1Controller.MoveRight();
                                }
                            }
                        }
                    }

                    if (myTouches[i].position.y > Screen.height / 2)
                    {
                        if (myTouches[i].position.y > Screen.height - 100)
                        {
                            gameController.player2Controller.PowerUp(1);
                        }
                        else
                        {
                            if (!player1.GetComponent<PlayerController>().oppositeIsActive)
                            {
                                if (myTouches[i].position.x > Screen.width / 2)
                                {
                                    gameController.player2Controller.MoveRight();
                                }
                                if (myTouches[i].position.x < Screen.width / 2)
                                {
                                    gameController.player2Controller.MoveLeft();
                                }
                            }else if (player1.GetComponent<PlayerController>().oppositeIsActive)
                            {
                                if (myTouches[i].position.x > Screen.width / 2)
                                {
                                    gameController.player2Controller.MoveLeft();
                                }
                                if (myTouches[i].position.x < Screen.width / 2)
                                {
                                    gameController.player2Controller.MoveRight();
                                }
                            }
                        }
                    }
                }
            }*/
        }
    }
}