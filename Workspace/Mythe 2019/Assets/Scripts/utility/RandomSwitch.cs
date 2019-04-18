using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSwitch : MonoBehaviour
{
    private float timer;
    private float goalTime;

    public event Action Switch;

    [SerializeField]
    private float minGoal, maxGoal;

    void Update()
    {
        //basic timer
        timer += Time.deltaTime;
        if (timer > goalTime)
        {
            NewGoal();
            timer = 0;
            Switch();            
        }
    }

    // sets a new goal
    void NewGoal()
    {
        goalTime = UnityEngine.Random.Range(minGoal, maxGoal);
    }
}
