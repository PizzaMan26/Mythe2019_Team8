using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private IsOnGround isOnGround;

    public GameObject target;

    private Health _enemyHealth;
    public float _enemySpeed;
    private Rigidbody2D rb;

    private bool isMoving;

    void Start()
    {
        isOnGround = GetComponent<IsOnGround>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isMoving == false)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        SlowDown();
    }


    public void CheckForPlayer()
    {
        if(target.transform.position.x <= transform.position.x)
        {
            rb.AddForce(new Vector3(-30, 0, 0));

            isMoving = true;
        }

        if (target.transform.position.x >= transform.position.x)
        {
            rb.AddForce(new Vector3(30, 0, 0));

            isMoving = true;
        }
    }

    private void SlowDown()
    {
        if (rb.velocity.x > 20)
        {
            rb.AddForce(new Vector3(-30, 0, 0));
        }
        else if (rb.velocity.x < -20)
        {
            rb.AddForce(new Vector3(30, 0, 0));
        }
    }


    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && isOnGround.CheckOnGround(gameObject.transform, 3.5f) == "Ground")
        {
            CheckForPlayer();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isMoving = false;
    }


    private void RunAway()
    {

    }
}

