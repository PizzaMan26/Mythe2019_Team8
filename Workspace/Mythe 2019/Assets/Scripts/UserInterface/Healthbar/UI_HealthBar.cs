using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
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
    private Text text;

    public int MaximumHealth {
        set {
            currentHealth = value;
        }
    }


    void Start()
    {

    }

    void RemoveHealth()
    {
        PlayAnimation();
        text.text = currentHealth + " / " + maximumHealth;
    }

    // Play page tear animation
    void PlayAnimation()
    {
        
    }
}
