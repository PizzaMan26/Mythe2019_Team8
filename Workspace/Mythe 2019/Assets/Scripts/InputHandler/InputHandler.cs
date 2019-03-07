using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public event Action Jump, Attack1, Attack2, Dash, Pause;
    public event Action<float> Walk;

    private bool Left = false, Right = false;


    // Check for input
    void Update()
    {
        if(Left != Right)
        {
            if (Left) Walk(-1);
            else if (Right) Walk(1);
        }
    }

    // Check which direction the player needs to move to
    public void InputLeftOn()
    {
        Left = true;
    }
    public void InputLeftOff()
    {
        Left = false;
    }

    public void InputRightOn()
    {
        Right = true;
    }
    public void InputRightOff()
    {
        Right = false;
    }

    // Send delegates
    public void InputJump()
    {
        Jump();
    }

    public void InputAttack1()
    {
        Attack1();
    }

    public void InputAttack2()
    {
        Attack2();
    }

    public void InputDash()
    {
        Dash();
    }

    public void InputPause()
    {
        Pause();
    }

}
    