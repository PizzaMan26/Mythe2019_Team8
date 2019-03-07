using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public event Action Jump, Attack1, Attack2, Pause;
    public event Action<float> Walk;

    private GameObject Left, Right;

    void Start()
    {
        Left = GameObject.FindWithTag("InputLeft");
        Right = GameObject.FindWithTag("InputRight");
    }

    // Check for input
    void Update()
    {
        if (Input.touchCount > 0)
        {
            print(Input.touchCount);
            // if the player holds the left or right button
            for(int i = 0; i < Input.touchCount; i++)
            {
                // check if the touch potition
                /*if() // check with pythagoras
                {

                }*/
            }

        }

        /*// Check if the application is running on android
        if (Application.platform == RuntimePlatform.Android)
        {
            print("android");
            // Check for touch input
            if (Input.touchCount > 0)
            {
                print(Input.touchCount);
                //if () Walk(value);
                //else Walk(0);

                //if () Jump();
                //if () Attack1();
                //if () Attack2();
            }
            //else Walk(0);
        }
        // Check if an controller is connected
        else if (Input.GetJoystickNames().Length > 0)
        {
            Walk(Input.GetAxis("C_Horizontal"));
            if (Input.GetButtonDown("C_Jump")) Jump();
            if (Input.GetButtonDown("C_Attack1")) Attack1();
            if (Input.GetButtonDown("C_Attack2")) Attack2();
            if (Input.GetButtonDown("C_Attack3")) Attack3();
        }
        // If the application is not running on android, and there is no controller connected, use PC controls
        else
        {
            Walk(Input.GetAxis("PC_Horizontal"));
            if (Input.GetButtonDown("PC_Jump")) print("jump");
            if (Input.GetButtonDown("PC_Attack1")) Attack1();
            if (Input.GetButtonDown("PC_Attack2")) Attack2();
            if (Input.GetButtonDown("PC_Attack3")) Attack3();
        }*/
    }

    // Send delegates
    public void InputLeft()
    {
        Walk(-1);
    }

    public void InputRight()
    {
        Walk(1);
    }

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

    public void InputPause()
    {
        Pause();
    }

}
    