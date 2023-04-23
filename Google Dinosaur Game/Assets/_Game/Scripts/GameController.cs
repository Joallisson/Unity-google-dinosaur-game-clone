using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [HideInInspector] public float timerDecrementEnemies;
    public float addDecrementEnemies;
    public bool gameStarted;
    private UIController uiController;
    [SerializeField] private GameObject cactoParent, cloudParent, birdParent;
    private EnemiesController enemiesController;
    private float savedTimerImcrementCamera, savedAddIncrementCamera;
    private float timerCountSpeed, timerCountSpeedBackground;
    public float speedBackgroundInfinty;
    private float InitSpeedBackgroundInfinty;

    // Start is called before the first frame update
    void Start()
    {
        gameStarted = false;
        uiController = FindObjectOfType<UIController>();
        enemiesController = FindObjectOfType<EnemiesController>();
        timerDecrementEnemies = 0;
        timerCountSpeed = 0;
        timerCountSpeedBackground = 0;
        InitSpeedBackgroundInfinty = speedBackgroundInfinty;
    }

    private void Update()
    {
        IncrementSpeedBackgroundInfiny();
        DecrementAndIncrementSpeed();
    }

    public void StartGame(bool value)
    {
        gameStarted = value;
    }

    public void RestartGame()
    {
        DestroyAllPrefabs();
        Time.timeScale = 1f;
        gameStarted = true;
        enemiesController.StopCreateEnemies();
        timerDecrementEnemies = 0;
        timerCountSpeedBackground = 0;

        speedBackgroundInfinty = InitSpeedBackgroundInfinty;
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        gameStarted = false;
        uiController.gameOverPanel.SetActive(true);

    }

    
    public void DestroyAllPrefabs()
    {
        foreach (Transform child in cactoParent.gameObject.transform)
        {
            Destroy(child.gameObject);
        }

        foreach(Transform child in cloudParent.gameObject.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (Transform child in birdParent.gameObject.transform)
        {
            Destroy(child.gameObject);
        }
    }

    private void DecrementAndIncrementSpeed()
    {
        if (gameStarted)
        {
            timerCountSpeed += Time.deltaTime * 10;
            if (timerCountSpeed >= 100)
            {
                if (enemiesController.timerInterval - timerDecrementEnemies > 1)
                {
                    timerDecrementEnemies += addDecrementEnemies;
                }

                timerCountSpeed = 0;
            }
        }
    }

    private void IncrementSpeedBackgroundInfiny()
    {
        if (gameStarted && speedBackgroundInfinty < 3)
        {
            timerCountSpeedBackground += Time.deltaTime * 10;

            if (timerCountSpeedBackground >= 100)
            {
                speedBackgroundInfinty += InitSpeedBackgroundInfinty;

                timerCountSpeedBackground = 0;
            }
        }
    }

}
