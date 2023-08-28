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
    private float counter, highScore, scoreForEachIncrement, scoreForEachDecrement;
    private string[] sizeScore = new string[5] { "00000", "0000", "000", "00", "0" };
    private GameController gameController;
    private Enemy enemy;
    private Background background;

    public SpawerEnemies spawerEnemies;

    private const float scoreInitialForEachIncrement = 200f; //DEPOIS MUDAR PARA 200f ===================================================
    private const float scoreForEachDecremntInTimeInstantiate = 500f; ////DEPOIS MUDAR PARA 500f ===================================================

    void Start()
    {
        ClearHighScore();
        player          = FindObjectOfType<Player>();
        gameController  = FindObjectOfType<GameController>();
        highScore = 0;
        countInitialTxtScore = 0;
        counter = countInitialTxtScore;
        enemy = FindObjectOfType<Enemy>();
        background = FindObjectOfType<Background>();
        scoreForEachIncrement = scoreInitialForEachIncrement;
        scoreForEachDecrement = scoreForEachDecremntInTimeInstantiate;
    }


    void Update()
    {
        UpdateScore();
        IncremnetSpeeds();
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
        player.SetInitialPosition();
        spawerEnemies.DestroyAllEnemiesChildren();
        Time.timeScale = 1f;
        scoreForEachIncrement = scoreInitialForEachIncrement;
        spawerEnemies.SetInitialVelocity();
        background.SetInitialVelocity();
        spawerEnemies.SetTotalTimeInstantiateForInitialValue();
        scoreForEachDecrement = scoreForEachDecremntInTimeInstantiate;
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

    public void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }

    private void IncremnetSpeeds()
    {
        if (counter > scoreForEachIncrement && spawerEnemies.speedEnemy <= 61 && background.getSpeedTexture() <= 6)
        {
            spawerEnemies.IncrementVelocitySpeed();
            background.IncrementVelocitySpeed();
            scoreForEachIncrement += scoreInitialForEachIncrement;
        }

        if(spawerEnemies.GetTotalTimeInstantiate() > 0.8 && counter > scoreForEachDecrement)
        {
            spawerEnemies.SubtractTotalTimeInstantiate();
            scoreForEachDecrement += scoreForEachDecremntInTimeInstantiate;
        }

    }

}
