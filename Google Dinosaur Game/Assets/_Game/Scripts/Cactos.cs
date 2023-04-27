using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactos : MonoBehaviour
{
    public float speed;
    private GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        this.transform.position -= Vector3.left * Time.deltaTime * -(speed + gameController.speedEnemyIncrement);
    }
}
