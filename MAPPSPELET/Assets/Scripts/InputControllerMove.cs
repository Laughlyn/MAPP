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
            //Player 1 keyboard controls
            if (Input.GetKey(KeyCode.Z))
            {
                gameController.player1Controller.MoveLeft();
            }
            if (Input.GetKey(KeyCode.X))
            {
                gameController.player1Controller.MoveRight();
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                gameController.player1Controller.PowerUp(2);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                gameController.player1Controller.PowerUp(1);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                gameController.player1Controller.PowerUp(3);
            }

            //Player 2 keyboard controls
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                gameController.player2Controller.MoveLeft();
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                gameController.player2Controller.MoveRight();
            }
            if (Input.GetKeyDown(KeyCode.N))
            {
                gameController.player2Controller.PowerUp(2);
            }
            if (Input.GetKeyDown(KeyCode.B))
            {
                gameController.player2Controller.PowerUp(1);
            }
            if (Input.GetKeyDown(KeyCode.M))
            {
                gameController.player2Controller.PowerUp(3);
            }

            //Mouse Controls
            if (mouseControls)
            {
                if (!Input.GetMouseButtonDown(0))
                {
                    gameController.player1Controller.Stop();
                    gameController.player2Controller.Stop();
                }
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
            Touch[] myTouches = Input.touches;
            if (Input.touchCount > 0)
            {
                for (int i = 0; i < Input.touchCount; i++)
                {
                    if (myTouches[i].position.y < Screen.height / 2)
                    {
                        if (myTouches[i].position.y < 100)
                        {
                            if (myTouches[i].position.x > Screen.width / 2 - 100 && myTouches[i].position.x > Screen.width / 2 + 100)
                            {
                                gameController.player1Controller.PowerUp(1);
                            }
                            if (myTouches[i].position.x > Screen.width / 3 - 100 && myTouches[i].position.x > Screen.width / 3 + 100)
                            {
                                gameController.player1Controller.PowerUp(2);
                            }
                            if (myTouches[i].position.x > ((Screen.width / 3) * 2) - 100 && myTouches[i].position.x > ((Screen.width / 3) * 2) + 100)
                            {
                                gameController.player1Controller.PowerUp(3);
                            }
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
                            }
                            else if (player2.GetComponent<PlayerController>().oppositeIsActive)
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
                            if (myTouches[i].position.x > Screen.width / 2 - 100 && myTouches[i].position.x > Screen.width / 2 + 100)
                            {
                                gameController.player2Controller.PowerUp(1);
                            }
                            if (myTouches[i].position.x > Screen.width / 3 - 100 && myTouches[i].position.x > Screen.width / 3 + 100)
                            {
                                gameController.player2Controller.PowerUp(2);
                            }
                            if (myTouches[i].position.x > ((Screen.width / 3) * 2) - 100 && myTouches[i].position.x > ((Screen.width / 3) * 2) + 100)
                            {
                                gameController.player2Controller.PowerUp(3);
                            }
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
                            }
                            else if (player1.GetComponent<PlayerController>().oppositeIsActive)
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
            }
        }
    }
}