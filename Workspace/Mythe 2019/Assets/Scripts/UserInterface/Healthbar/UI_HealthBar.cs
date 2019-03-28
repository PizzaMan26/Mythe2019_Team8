﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_HealthBar : MonoBehaviour
{
    /* Misschien kunnen we regelen dat de ruimte tussen de achterste
     * bladzijde en het boek een var is, waardoor we een kleinbeetje kunnen
     * zien hoeveel bladzijdes er nog ongeveer zijn.
     * dan voor de teat animation maken we een animatie waarbij ze van beneden
     * naar boven worden gescheurd, zodat we met code de bladzijdes naar boven
     * kunnen bewegen, en dan langzaam kunnen vervagen
     * 
     */



    private int maximumHealth, currentHealth;
    [SerializeField]
    private Text txt_curHealth, txt_maxHealth;

    //private Health playerHealth;

    public int MaximumHealth {
        set {
            maximumHealth = value;
            txt_maxHealth.text = maximumHealth.ToString();
        }
    }


    void Start()
    {
        //playerHealth = GameObject.FindWithTag("Player").GetComponent(Health);
        //playerHealth.playerHit += RemoveHealth;
    }

    void RemoveHealth(int amount)
    {
        currentHealth = amount;
        if (currentHealth < 0) currentHealth = 0;
        
        PlayAnimation();
        txt_curHealth.text = currentHealth.ToString();
    }

    // Play page tear animation
    void PlayAnimation()
    {
        
    }
}