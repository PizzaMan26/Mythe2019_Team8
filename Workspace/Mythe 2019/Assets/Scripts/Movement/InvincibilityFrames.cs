using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibilityFrames : MonoBehaviour
{
    [HideInInspector]
    public bool isInvincible = false;//while this is true player can't take damage
    private AnimationHandler AN;

    void Start()
    {
        AN = gameObject.GetComponent<AnimationHandler>();
    }

    public void BeInvincible()
    {
        isInvincible = true;
        AN.DashAnim();
    }

    public void StopInvincibilaty()
    {
        isInvincible = false;
    }
}
