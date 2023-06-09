using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    public int speedJumping;
    public float counterJump;
    private float totalCounterJump;
    private bool isJumping, isGrounding, canJump;
    private Animator animatorPlayer;
    private GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        totalCounterJump = counterJump;
        isJumping = false;
        isGrounding = true;
        canJump = true;
        animatorPlayer = GetComponentInChildren<Animator>();
        gameController = FindObjectOfType<GameController>();
    }

    private void FixedUpdate()
    {
        Jumping();
    }

    // Update is called once per frame
    void Update()
    {
        TouchScreen();
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.CompareTag("Cactus") || target.gameObject.CompareTag("Bird"))
        {
            gameController.GameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        if(target.gameObject.CompareTag("Ground"))
        {
            canJump = true;
            isGrounding = true;
            counterJump = totalCounterJump;

        }
    }

    private void OnCollisionExit2D(Collision2D target)
    {
        if (target.gameObject.CompareTag("Ground"))
        {
            isGrounding = false;
        }
    }

    private void TouchScreen()
    {

        if (Input.touchCount > 0 && canJump)
        {
            counterJump -= Time.deltaTime;

            if (counterJump > 0)
            {
                isJumping = true;
            }
            else
            {
                canJump = false;
                isJumping = false;
            }

        }
        else if (!isGrounding)
        {
            canJump = false;
            isJumping = false;
        }

    }

    private void Jumping()
    {
        if (isJumping)
        {
            rb.velocity = Vector2.up * speedJumping;
        }
    }
    
    public void ChangeAnimation()
    {
        animatorPlayer.SetBool("isRuning", true);
    }
}
