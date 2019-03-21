using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health = 100;
    public bool isPlayer = false;
    private Rigidbody2D _rb;

    private GameObject IF;

    public event Action playerDead;
    public event Action<int> playerHit;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();//get's the rigidbody2D
    }

    public void DealDamage(int damage)//deals damage to object
    {
        if (!GetComponent<InvincibilityFrames>().isInvincible)
        {
            health = health - damage;
            if (isPlayer)
            {
                playerHit(health);
            }
        }
        

        if(health <= 0)//wasted
        {
            if (isPlayer)
            {
                playerDead();
            } 
            Debug.Log("RIP in perpperonies");
        }
    }

    public void OnHit(float force)//knockup for juggling
    {
        Vector2 push = new Vector2(Input.GetAxis("Horizontal"), force);
        _rb.AddForce(push);
    }


    public void Juggle(float amount)//resets velocity for juggling
    {
        print(GetComponent<IsOnGround>().CheckOnGround(transform, 3.5f));
        if (GetComponent<IsOnGround>().CheckOnGround(transform, 3.5f) != "Ground")
        {
            _rb.velocity = new Vector2(0, amount);
        }
    }


}
