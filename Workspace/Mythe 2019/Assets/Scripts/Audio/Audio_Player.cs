using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Player : MonoBehaviour
{
    private AudioManager audioManager;

    [SerializeField]
    private AudioSource Land_Source;
    [SerializeField]
    private AudioSource Run_Source;

    void Awake()
    {
        audioManager = GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>();
        audioManager.Player_Land += Land;
        audioManager.Player_Run += Run;
    }

    private void Land()
    {
        Land_Source.Play(0);
    }

    private void Run(bool isMoving)
    {
        if (isMoving)
        {
            Run_Source.Play(0);//???
        }
        else
        {
            Run_Source.Stop();
        }
    }
}
