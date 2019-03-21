using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceTrigger : MonoBehaviour
{
    Health enemyHealth;

    private bool hasSpokenAttack = false;
    private bool hasSpokenBack = false;
    private bool hasSpokenDie = false;


    void OnTriggerStay2D(Collider2D col)
    {
        if (!hasSpokenAttack)
        {
            hasSpokenAttack = true;
        }
        
        if (!hasSpokenBack && enemyHealth.health <= 40)
        {
            hasSpokenBack = true;
        }
        
        if (!hasSpokenDie && enemyHealth.health <= 0)
        {
            hasSpokenDie = true;
        }
    }

 
}
