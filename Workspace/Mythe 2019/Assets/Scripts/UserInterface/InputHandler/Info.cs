using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Info : MonoBehaviour
{
    /*
    This script is an example.
    In this script you can see how the InputHandler script can be used.  
    */
    
    private InputHandler inputHandler;

    void Start()
    {
        inputHandler = GameObject.FindWithTag("InputHandler").GetComponent<InputHandler>();

        //inputHandler.Jump += /*Zet hier een functie neer.*/;
        //inputHandler.Attack1 += /*Zet hier een functie neer.*/;
        //inputHandler.Attack2 += /*Zet hier een functie neer.*/;
        //inputHandler.Attack3 += /*Zet hier een functie neer.*/;
        //inputHandler.Walk += /*Zet hier een functie neer.*/;
    }

}
