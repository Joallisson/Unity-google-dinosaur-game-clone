using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UIController : MonoBehaviour
{
    public GameObject startGamePanel, gameOverPanel;
    private Player player;
    public TMP_Text txtScore, txtHighScore;
    private int countInitialTxtScore;
    private float counter, highScore;
    private string[] sizeScore = new string[5] {"00000", "0000", "000", "00", "0" };
    private GameController gameController;

    public SpawerEnemies spawerEnemies;

    void Start()
    {
        ClearHighScore();
        player          = FindObjectOfType<Player>();
        gameController  = FindObjectOfType<GameController>();

        highScore = 0;
        countInitialTxtScore = 0;
        counter = countInitialTxtScore;

    }


    void Update()
    {
        UpdateScore();
    }

    public void ClickPanelStartGame()
    {
        player.ChangeAnimationToRun();
        startGamePanel.SetActive(false);
        gameController.StartGame();
        spawerEnemies.gameObject.SetActive(true);

    }

    public void ButtonRestartGame()
    {
        gameOverPanel.SetActive(false);
        SaveHighScore();
        counter = 0;
        txtScore.text = "000000";
    }

    private void UpdateScore()
    {
        if (gameController.isStartedGame)
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
