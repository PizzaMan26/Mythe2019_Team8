using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Player : MonoBehaviour
{
    private AudioManager audioManager;

    [SerializeField]
    private AudioSource Land_Source;

    void Awake()
    {
        audioManager = GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>();
        audioManager.Player_Land += Land;
    }

    private void Land()
    {
        Land_Source.Play(0);
    }
}
