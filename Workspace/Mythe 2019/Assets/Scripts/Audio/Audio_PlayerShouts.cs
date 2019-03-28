using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_PlayerShouts : MonoBehaviour
{
    private int randomShout;
    private AudioManager audioManager;

    [SerializeField]
    private AudioSource Shout1_Source;

    void Awake()
    {
        audioManager = GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>();
        audioManager.Player_Shout += Shout;
    }
    
    private void Shout()
    {
        randomShout = Random.Range(1, 1);
        switch (randomShout)
        {
            case 1:
                Shout1_Source.Play(0);
                break;
            default:
                break;
        }
    }
}
