using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLand : MonoBehaviour
{
    private AudioManager audioManager;
    private IsOnGround isOnGround;

    private bool firstTimeOnGround = false;

    void Awake()
    {
        isOnGround = GetComponent<IsOnGround>();
        audioManager = GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>();
    }

    void Update()
    {
        if (isOnGround.CheckOnGround(transform, 2.5f) != "Ground")
        {
            firstTimeOnGround = true;
        }
        if (isOnGround.CheckOnGround(transform, 2.5f) == "Ground" && firstTimeOnGround == true)
        {
            firstTimeOnGround = false;
            Land();
        }
    }

    public void Land()
    {
        audioManager.PlayerLand();
    }
}
