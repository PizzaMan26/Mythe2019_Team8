using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private int _health = 100;
    private Rigidbody2D _rb;
    private GameObject GameManager;

    void Start()
    {
        GameManager = GameObject.Find("GameManager");
        _rb = GetComponent<Rigidbody2D>();//get's the rigidbody2D
    }

    public void DealDamage(int damage)//deals damage to object
    {
        _health = _health - damage;

        if(_health <= 0)//wasted
        {
            Debug.Log("RIP in perpperonies");
        }
    }

    public void OnHit(float force)//knockup for throwing in the air
    {
        Vector2 push = new Vector2(Input.GetAxis("Horizontal"), force);
        _rb.AddForce(push);
    }

    public void Juggle(float amount)//resets velocity for juggling
    {
        if (GameManager.GetComponent<IsOnGround>().CheckOnGround(transform, 3.5f) == null)
        {
            _rb.velocity = new Vector2(0, amount);
        }
    }


}
