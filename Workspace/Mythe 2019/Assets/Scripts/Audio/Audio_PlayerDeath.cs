using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_PlayerDeath : MonoBehaviour
{
    private int randomDeath;
    private AudioManager audioManager;

    [SerializeField]
    private AudioSource Death1_Source;

    void Awake()
    {
        audioManager = GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>();
        audioManager.Player_Death += Death;
    }

    private void Death()
    {
        randomDeath = Random.Range(1, 1);
        switch (randomDeath)
        {
            case 1:
                Death1_Source.Play(0);
                break;
            default:
                break;
        }
    }
}
