using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactos : MonoBehaviour
{
    private Rigidbody2D rb2D;
    public float speed;
    private GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
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
