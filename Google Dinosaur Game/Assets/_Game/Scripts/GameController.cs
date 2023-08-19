using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [HideInInspector] public bool isStartedGame = false;
    void Start()
    {

    }

    void Update()
    {
        
    }

    public void StartGame()
    {
        isStartedGame = true;
    }

    public void GameOver()
    {
        Time.timeScale = 0;
    }

}
