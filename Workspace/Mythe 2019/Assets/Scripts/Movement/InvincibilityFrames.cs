using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibilityFrames : MonoBehaviour
{
    [HideInInspector]
    public bool isInvincible = false;//while this is true player can't take damage

    public void BeInvincible()
    {
        isInvincible = true;
    }

    public void StopInvincibilaty()
    {
        isInvincible = false;
    }
}
