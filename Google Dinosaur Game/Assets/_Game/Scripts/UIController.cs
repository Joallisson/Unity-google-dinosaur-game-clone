using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UIController : MonoBehaviour
{
    private Player player;
    public GameObject startGamePanel, gameOverPanel;
    private GameController gameController;
    public TMP_Text txtScore, txtHighScore;
    private int countInitialTxtScore;
    private float counter, highScore;
    private string[] sizeScore = new string[5] {"00000", "0000", "000", "00", "0" };
    private EnemiesController enemiesController;

    // Start is called before the first frame update
    void Start()
    {
        ClearHighScore();
        player = FindObjectOfType<Player>();
        gameController = FindObjectOfType<GameController>();
        highScore = 0;
        countInitialTxtScore = 0;
        counter = countInitialTxtScore;
        enemiesController = FindObjectOfType<EnemiesController>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();
    }

    public void ClickPanelStartGame()
    {
        player.ChangeAnimation();
        startGamePanel.SetActive(false);
        gameController.StartGame(true);
       
    }

    public void ButtonRestartGame()
    {
        gameController.RestartGame();
        gameOverPanel.SetActive(false);
        SaveHighScore();
        counter = 0;
        txtScore.text = "000000";
    }

    private void UpdateScore()
    {
        if (gameController.gameStarted)
        {
            counter += Time.deltaTime * 10;
            string scoreText = sizeScore[counter.ToString("00").Length - 1] + counter.ToString("00");
            txtScore.text = scoreText;
        }
    }

    private void SaveHighScore()
    {
        if(counter > highScore)
        {
            highScore = counter;
            txtHighScore.text = "HI " + sizeScore[highScore.ToString("00").Length - 1] + highScore.ToString("00");
            PlayerPrefs.SetString("highScore", highScore.ToString());
        }
    }

    private void ClearHighScore()
    {
        PlayerPrefs.DeleteKey("highScore");
    }

    

}
