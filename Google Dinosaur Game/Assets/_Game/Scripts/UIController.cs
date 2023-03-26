using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    private Player player;
    public GameObject startGamePanel;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickPanelStartGame()
    {
        player.ChangeAnimation();
        startGamePanel.SetActive(false);
    }
}
