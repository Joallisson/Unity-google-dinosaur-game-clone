using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    private Player player;
    public GameObject startGamePanel, gameOverPanel;
    private GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        gameController = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
    }
}
