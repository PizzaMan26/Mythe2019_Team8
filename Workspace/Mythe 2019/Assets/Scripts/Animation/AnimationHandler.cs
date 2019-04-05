using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    private InputHandler inputHandler;
    private Health health;
    private InvincibilityFrames IF;
    private Animator anim;
    private bool hasDashed = false;
    private AnimationState state;
    private AnimationClip dashAnimation;

    private SpriteRenderer SR;

    private void Awake()
    {
        SR = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        inputHandler = GameObject.Find("InputHandler").GetComponent<InputHandler>();
        health = GameObject.Find("Health").GetComponent<Health>();
        IF = gameObject.GetComponent<InvincibilityFrames>();
        inputHandler.Jump += JumpAnim;
        inputHandler.Walk += RunAnim;

    }

    private void RunAnim(float amount)
    {
        if(amount != 0)
        {
            anim.SetBool("doRuning", true);
        }
        else
        {
            anim.SetBool("doRuning", false);
        }
        if (SR != null && amount == -1)
        {
            SR.flipX = true;
        }
        else if (SR !=null && amount == 1)
        {
            SR.flipX = false;
        }

    }

    private void JumpAnim()
    {
        anim.SetTrigger("doJumping");
    }

    public void DashAnim()
    {
        anim.SetTrigger("doDash");
    }

    private void DeathAnim()
    {
        anim.SetBool("doDead", true);
    }

}
