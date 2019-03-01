using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float movementspeed = 0;
    [SerializeField]
    private float jumpForce = 500;

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
        RaycastHit2D hit = Physics2D.Raycast(new Vector3(transform.position.x, transform.position.y - 1.65f, transform.position.z), transform.TransformDirection(Vector3.down), .1f);
        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y - 1.65f, transform.position.z), transform.TransformDirection(Vector3.down) * .1f, Color.yellow);
        if (hit.collider != null)//check the raycast hits anything
        {
            //checks if on the ground
            if (hit.collider.gameObject.tag == "Ground")
            {
                canJump = true;
            }
        }
        else //when your the raycast doesn't hit anything it wont't go of
        {
            canJump = false;
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
    {// if when amount > 0 go make a ray and check if it hits somthing. if it hits go up a bit
        /*
        float relocation;
        if (amount > 0)
        {
            RaycastHit2D hit = Physics2D.Raycast(new Vector3(transform.position.x + 1, transform.position.y - 1.3f, transform.position.z), transform.TransformDirection(Vector3.right), .3f);
            Debug.DrawRay(new Vector3(transform.position.x + 1, transform.position.y - 1.3f, transform.position.z), transform.TransformDirection(Vector3.right) * .3f, Color.yellow);
            if (hit.collider != null)//check the raycast hits anything
            {
                if (hit.collider.gameObject.tag == "Ground")
                {
                    relocation = 0.2f;
                }
            }
            else
            {
                relocation = 0;
            }
        }
        */
        //transform.Translate(new Vector3(amount, 0, 0) * Time.deltaTime * movementspeed);
        rb.MovePosition(transform.position + new Vector3(amount, 0, 0) * Time.deltaTime * movementspeed);
    }
}
