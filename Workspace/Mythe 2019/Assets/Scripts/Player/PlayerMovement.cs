using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //[SerializeField]
    //private float movementspeed = 0;
    [SerializeField]
    private float jumpForce = 500;

    private bool isMoving = false;

    private Rigidbody2D rb;
    private InputHandler inputHandler;

    private bool canJump = false;

    void Start()
    {
        inputHandler = GameObject.FindWithTag("InputHandler").GetComponent<InputHandler>();
        rb = GetComponent<Rigidbody2D>();
        //delicate's from the inputHandler
        inputHandler.Jump += JumpUp;
        inputHandler.Walk += Walk;
    }

    void Update()
    { // still needto make more raycast to check if he can jump even if it is not directly above an object
        RaycastHit2D hit = Physics2D.Raycast(new Vector3(transform.position.x, transform.position.y - 3.65f, transform.position.z), transform.TransformDirection(Vector3.down), .3f);
        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y - 3.65f, transform.position.z), transform.TransformDirection(Vector3.down) * .3f, Color.yellow);
        if (hit.collider != null)//check the raycast hits anything
        {
            //checks if on the ground
            if (hit.collider.gameObject.tag == "Ground")
            {
                canJump = true;
                SlowDown();
            }
        }
        else //when your the raycast doesn't hit anything it wont't go of
        {
            canJump = false;
        }

    }

    private void StopMoving()
    {

    }

    //slows down if player goes to fast and hits the ground
    private void SlowDown()
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
        isMoving = true;
        //checks if the force isn't to high enough
        if (rb.velocity.x < 20 && rb.velocity.x > -20)
        {
            //adds force for walking
            rb.AddForce(new Vector3(amount * 1000, 0, 0));
        }
    }
}
