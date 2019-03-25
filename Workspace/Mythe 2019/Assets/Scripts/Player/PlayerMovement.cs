using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private AudioManager audioManager;

    [SerializeField]
    private float jumpForce = 500;

    private bool isMoving = false;
    private string collidingTarget;

    private Rigidbody2D rb;
    private InputHandler inputHandler;
    private GameObject GameManager;

    private bool canJump = false;

    void Start()
    {
        audioManager = GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>();
        inputHandler = GameObject.FindWithTag("InputHandler").GetComponent<InputHandler>();
        rb = GetComponent<Rigidbody2D>();
        //delicate's from the inputHandler
        inputHandler.Jump += JumpUp;
        inputHandler.Walk += Walk;
    }

    void Update()
    { 
        StopMoving();
        audioManager.PlayerRun(isMoving);
        print(isMoving);

        collidingTarget = GetComponent<IsOnGround>().CheckOnGround(transform, 3f);
        if (collidingTarget == "Ground")
        {
            canJump = true;
            OnGroundMovement();
        }
        else
        {
            canJump = false;
        }

    }

    private void StopMoving()
    {
        if (isMoving == false)
        {
            if (rb.velocity.x > 0)
            {
                rb.AddForce(new Vector3(-200, 0, 0));
            }
            if (rb.velocity.x < 0)
            {
                rb.AddForce(new Vector3(200, 0, 0));
            }
        }
    }

    //slows down if player goes to fast and hits the ground
    private void OnGroundMovement()
    {
        if (rb.velocity.x > 20)
        {
            rb.AddForce(new Vector3(-1000, 0, 0));
        }
        else if (rb.velocity.x < -20)
        {
            rb.AddForce(new Vector3(1000, 0, 0));
        }
    }

    private void JumpUp()
    {
        //should happen if you press one of the jump buttons
        if (canJump == true)
        {
            rb.AddForce(new Vector3(0, jumpForce, 0)); // adds force to emulate a jump.
        }
    }

    private void Walk(float amount)
    {
        if (amount == 0)
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }
        //checks if the force isn't to high enough
        if (rb.velocity.x < 20 && rb.velocity.x > -20)
        {
            //adds force for walking
            rb.AddForce(new Vector3(amount * 1000, 0, 0));
        }
    }
}
