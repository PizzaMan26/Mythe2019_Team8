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

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    { // still needto make more raycast to check if he can jump even if it is not directly above an object
        RaycastHit2D hit = Physics2D.Raycast(new Vector3(transform.position.x, transform.position.y - 1.5f, transform.position.z), transform.TransformDirection(Vector3.down), .1f);
        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y - 1.5f, transform.position.z), transform.TransformDirection(Vector3.down) * .1f, Color.yellow);
        if (hit.collider != null)//check the raycast hits anything
        {
            //checks if on the ground
            if (hit.collider.gameObject.tag == "Ground")
            {
                if (Input.GetKeyDown("space"))//change to axis of controler button
                {
                    print("jump");
                    rb.AddForce(new Vector3(0, jumpForce, 0));
                }
            }
        }
        if (true/*axis of Controler horisontal != 0*/) //check if you axis changed so you can start moving
        {
            transform.Translate(new Vector3(-1/*axis*/, 0,0)* Time.deltaTime * movementspeed);
        }
    }
}
