using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private SpawerEnemies spawerEnemies;
    private float speedEnemy;

    private float leftBorder;
    private GameController gameController;

    void Start()
    {
        leftBorder = Camera.main.ScreenToViewportPoint(Vector3.zero).x -15;
        gameController = FindObjectOfType<GameController>();
        spawerEnemies = FindObjectOfType<SpawerEnemies>();
        speedEnemy = spawerEnemies.speedEnemy;
    }

    void Update()
    {
        Backward();
        DestroyEnemy();
    }

    private void Backward()
    {
        if(gameController.isStartedGame)
        {
            transform.position += new Vector3(-speedEnemy * Time.deltaTime, 0, 0);
        }
    }

    private void DestroyEnemy()
    {
        if(transform.position.x  <= leftBorder)
        {
            Destroy(gameObject);
        }
    }
}
