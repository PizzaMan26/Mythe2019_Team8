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
        isOnGround = GameObject.Find("GameManager").GetComponent<IsOnGround>();
        audioManager = GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>();
    }

    void Update()
    {
        if (isOnGround.CheckOnGround(transform, 3f) == null)
        {
            firstTimeOnGround = true;
        }
        if (isOnGround.CheckOnGround(transform, 3f) != null && firstTimeOnGround == true)
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
