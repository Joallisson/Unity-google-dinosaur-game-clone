using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float timePlus;
    public bool gameStarted;
    private UIController uiController;
    private CameraMain cameraMain;
    [SerializeField] private GameObject cactoParent, cloudParent;

    // Start is called before the first frame update
    void Start()
    {
        gameStarted = false;
        uiController = FindObjectOfType<UIController>();
        cameraMain = FindObjectOfType<CameraMain>();
    }

    // Update is called once per frame
    void Update()
    {
      
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
    }
    
}
