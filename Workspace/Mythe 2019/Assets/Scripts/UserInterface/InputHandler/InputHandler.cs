using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    // Delegates
    public event Action Jump, Attack1, Attack2;
    public event Action<bool> Pause;
    public event Action<float> Walk, Dash;

    // Variables to support the delegates
    private bool Left = false, Right = false, Paused = false;
    private float Direction = 1;


    void Update()
    {
        // Check if the player is moving
        if (Left) Walk(-1);
        else if (Right) Walk(1);
        else if (!Left && !Right) Walk(0);
    }

    // Check which direction the player needs to move to
    public void InputLeftOn()
    {
        Left = true;
        Direction = -1;
    }
    public void InputLeftOff()
    {
        Left = false;
    }

    public void InputRightOn()
    {
        Right = true;
        Direction = 1;
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
        Dash(Direction);
    }

    public void InputPause()
    {
        Paused = !Paused;
        Pause(Paused);
    }

}
    