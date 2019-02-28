using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public event Action Jump, Attack1, Attack2, Attack3;
    public event Action<float> Walk;

    // Check for input
    void Update()
    {   
        // Check if the application is running on android
        if (Application.platform == RuntimePlatform.Android)
        {
            //if () Walk(value);
            //if () Jump();
            //if () Attack1();
            //if () Attack2();
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
        }
    }
}
