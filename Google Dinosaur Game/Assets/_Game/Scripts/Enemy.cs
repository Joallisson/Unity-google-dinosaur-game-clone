using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speedEnemy;
    private float leftBorder;

    void Start()
    {
        leftBorder = Camera.main.ScreenToViewportPoint(Vector3.zero).x -15;
    }

    void Update()
    {
        Backward();
        DestroyEnemy();
    }

    private void Backward()
    {
        transform.position += new Vector3(-speedEnemy * Time.deltaTime, 0, 0);
    }

    private void DestroyEnemy()
    {
        if(transform.position.x  <= leftBorder)
        {
            Destroy(gameObject);
        }
    }
}
