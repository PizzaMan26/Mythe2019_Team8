using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    private Rigidbody2D _rb;

    public float force = 0;
    public float cooldown = 1f;
    private float _CD;
    private bool _isDashing = false;

    private InputHandler inputHandler;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        inputHandler = GameObject.FindWithTag("InputHandler").GetComponent<InputHandler>();
        inputHandler.Dash += DashTowards;
    }

    void Update()
    {
        DashCooldown();
    }

    private void DashCooldown()//cooldown of the dash
    {
        _CD -= Time.deltaTime;
        if (GetComponent<StartAttack>().curCD <= 0) {
            _isDashing = false;                       
        }
    }


    private void DashTowards(float value)
    {
        if (_CD <= 0 && value == 1) // dash left
        {
            _rb.AddForce(transform.right * force);
            _CD = cooldown;
            _isDashing = true;
            GetComponent<InvincibilityFrames>().BeInvincible();
        }
        else if (_CD <= 0 && value == -1)//dash right
        {
            _rb.AddForce(transform.right * -force);
            _CD = cooldown;
            _isDashing = true;
            GetComponent<InvincibilityFrames>().StopInvincibilaty();
        }
    }
}
