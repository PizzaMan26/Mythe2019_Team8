using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLand : MonoBehaviour
{
    private AudioManager audioManager;

    void Awake()
    {
        audioManager = GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown("space")/*need utility for checking if he hits ground*/)
        {
            Land();
        }
    }

    public void Land()
    {
        audioManager.PlayerLand();
    }
}
