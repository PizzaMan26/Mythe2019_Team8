using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health = 100;
    private Rigidbody2D _rb;

    private GameObject IF;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();//get's the rigidbody2D
    }

    public void DealDamage(int damage)//deals damage to object
    {
        if (!GetComponent<InvincibilityFrames>().isInvincible)
        {
            health = health - damage;
        }
        

        if(health <= 0)//wasted
        {
            Debug.Log("RIP in perpperonies");
        }
    }

    public void OnHit(float force)//knockup for juggling
    {
        Vector2 push = new Vector2(Input.GetAxis("Horizontal"), force);
        _rb.AddForce(push);
    }


}
