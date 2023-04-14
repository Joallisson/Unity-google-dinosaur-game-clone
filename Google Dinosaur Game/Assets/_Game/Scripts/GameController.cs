using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float timePlus, timerInstantiete;
    public bool gameStarted;
    private UIController uiController;
    private CameraMain cameraMain;
    [SerializeField] private GameObject cactoParent, cloudParent, birdParent;
    private EnemiesController enemiesController;

    // Start is called before the first frame update
    void Start()
    {
        gameStarted = false;
        uiController = FindObjectOfType<UIController>();
        cameraMain = FindObjectOfType<CameraMain>();
        enemiesController = FindObjectOfType<EnemiesController>();
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
    
}
