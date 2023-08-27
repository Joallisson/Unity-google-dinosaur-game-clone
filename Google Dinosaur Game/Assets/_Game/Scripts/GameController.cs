using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [HideInInspector] public bool isStartedGame;
    private UIController uIController;

    void Start()
    {
        uIController = FindObjectOfType<UIController>();
        isStartedGame = false;
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
        uIController.ShowGameOverPanel();
        Time.timeScale = 0;
    }

}
