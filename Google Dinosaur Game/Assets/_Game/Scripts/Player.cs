using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] float forceJump;
    private bool isTouchingGround;
    private Animator animator;
    private GameController gameController;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        gameController = FindObjectOfType<GameController>();
    }

    
    void Update()
    {
        Jump();
    }

    private void Jump()
    {
        if (gameController.isStartedGame && isTouchingGround && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            rb.velocity = new Vector2(0, forceJump);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isTouchingGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isTouchingGround = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Cactus"))
        {
            Debug.Log("GAME OVER >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
        }
    }

    public void ChangeAnimationToRun()
    {
        animator.SetBool("isRuning", true);
    }

}
