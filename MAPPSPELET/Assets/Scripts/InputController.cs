using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
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
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            gameController.BackToMenu();
            return;
        }

        if (!gameController.gameOver)
        {
            //Mouse Controls
            if (Input.GetMouseButtonDown(0))
            {
                if (Input.mousePosition.y < Screen.height / 2 && gameController.player1Controller.bulletTimer > gameController.player1Controller.bulletDelay)
                {
                    gameController.player1Controller.SpawnProjectile();
                    gameController.player1Controller.bulletTimer = 0;
                }
                if (Input.mousePosition.y > Screen.height / 2 && gameController.player2Controller.bulletTimer > gameController.player2Controller.bulletDelay)
                {
                    gameController.player2Controller.SpawnProjectile();
                    gameController.player2Controller.bulletTimer = 0;
                }
            }


            //Touch Controls
            Touch[] myTouches = Input.touches;
            if (Input.touchCount > 0)
            {
                for (int i = 0; i < Input.touchCount; i++)
                {
                    if (myTouches[i].position.y < Screen.height / 2 && gameController.player1Controller.bulletTimer > gameController.player1Controller.bulletDelay)
                    {
                        gameController.player1Controller.SpawnProjectile();
                        gameController.player1Controller.bulletTimer = 0;


                    }
                    if (myTouches[i].position.y > Screen.height / 2 && gameController.player2Controller.bulletTimer > gameController.player2Controller.bulletDelay)
                    {
                        gameController.player2Controller.SpawnProjectile();
                        gameController.player2Controller.bulletTimer = 0;


                    }
                }
            }
        }
    }
}
