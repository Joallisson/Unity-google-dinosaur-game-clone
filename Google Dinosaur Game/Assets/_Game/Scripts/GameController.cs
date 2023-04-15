using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [HideInInspector] public float timerDecrementEnemies;
    public float addDecrementEnemies, addIncrementCamera, timerImcrementCamera;
    public bool gameStarted;
    private UIController uiController;
    private CameraMain cameraMain;
    [SerializeField] private GameObject cactoParent, cloudParent, birdParent;
    private EnemiesController enemiesController;
    private float savedTimerImcrementCamera, savedAddIncrementCamera;
    private float timerCountSpeed;

    // Start is called before the first frame update
    void Start()
    {
        gameStarted = false;
        uiController = FindObjectOfType<UIController>();
        cameraMain = FindObjectOfType<CameraMain>();
        enemiesController = FindObjectOfType<EnemiesController>();
        timerDecrementEnemies = 0;
        savedTimerImcrementCamera = timerImcrementCamera;
        timerCountSpeed = 0;

    }

    private void Update()
    {
        DecrementAndIncrementSpeed();
    }

    public void StartGame(bool value)
    {
        gameStarted = value;
    }

    public void RestartGame()
    {
        DestroyAllPrefabs();
        cameraMain.PosInitialCamera();
        Time.timeScale = 1f;
        gameStarted = true;
        enemiesController.StopCreateEnemies();
        timerDecrementEnemies = 0;
        timerImcrementCamera = savedTimerImcrementCamera;
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
            if (timerCountSpeed >= 50)
            {
                if (enemiesController.timerInterval - timerDecrementEnemies > 1)
                {
                    timerDecrementEnemies += addDecrementEnemies;
                }

                if (timerImcrementCamera < 1.6f)
                {
                    timerImcrementCamera += addIncrementCamera;
                }

                timerCountSpeed = 0;
            }
        }
    }

}
