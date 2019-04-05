using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    private InputHandler inputHandler;
    private InvincibilityFrames IF;
    private Animator anim;
    private SpriteRenderer SR;

    private void Awake()
    {
        SR = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        inputHandler = GameObject.Find("InputHandler").GetComponent<InputHandler>();
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

}
