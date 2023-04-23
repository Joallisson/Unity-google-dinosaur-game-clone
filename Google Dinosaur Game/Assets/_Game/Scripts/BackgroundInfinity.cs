using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundInfinity : MonoBehaviour
{
    public float speed;
    private GameController gameController;

    private void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveBackground();
    }

    private void MoveBackground()
    {
        if(gameController.gameStarted)
        {
            Vector2 displacement = new Vector2(Time.time * (speed + gameController.speedBackgroundInfinty), 0);
            GetComponent<Renderer>().material.mainTextureOffset = displacement;
        }
    }

}
