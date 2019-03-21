using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceTrigger : MonoBehaviour
{
    Health enemyHealth;
    private VoiceLines voice;
    private Languages lang;

    private bool hasSpokenAttack = false;
    private bool hasSpokenBack = false;
    private bool hasSpokenDie = false;

    void Start()
    {
        voice = GameObject.Find("VoiceLines").GetComponent<VoiceLines>();
        lang = voice.RandomLanguage();
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            if (!hasSpokenAttack)
            {
                hasSpokenAttack = true;
                voice.PlayLanguage(lang, "Attack");
            }

            if (!hasSpokenBack && GetComponent<Health>().health <= 40)
            {
                hasSpokenBack = true;
                voice.PlayLanguage(lang, "Back");
            }

            if (!hasSpokenDie && GetComponent<Health>().health <= 0)
            {
                hasSpokenDie = true;
                voice.PlayLanguage(lang, "Death");
            }
        }
    }

 
}
