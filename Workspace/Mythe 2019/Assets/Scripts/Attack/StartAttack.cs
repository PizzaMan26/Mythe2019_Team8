using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAttack : MonoBehaviour
{
    private GameObject _AttackBox;
    private float _lightCD = 0.3f;
    private float _heavyCD = 0.9f;
    [HideInInspector]
    public float curCD = 0f;

    [HideInInspector]
    public int curAttack = 0;
    //0 = none
    //1 = light
    //2 = heavy


    void Start()
    {
        _AttackBox = transform.GetChild(0).gameObject;//get's the attack hitbox
    }


    void Update()
    {
        if (curCD <= 0 && Input.GetKeyDown(KeyCode.Mouse0))//Light attack
        {
            LightAttack();
            curCD = _lightCD;
            curAttack = 1;
        }

        if (curCD <= 0 && Input.GetKeyDown(KeyCode.Mouse1))//Heavy attack
        {
            HeavyAttack();
            curCD = _heavyCD;
            curAttack = 2;
        }


        if (curCD > 0)//countdown timer
        {
            curCD = curCD - Time.deltaTime;
            if (_AttackBox.activeSelf && curCD <= 0.2f)//stop attacking
            {
                _AttackBox.SetActive(false);
                curAttack = 0;
            }
        }
    }

    //enables attack hitbox
    private void LightAttack()
    {
        _AttackBox.SetActive(true);
    }

    private void HeavyAttack()
    {
        _AttackBox.SetActive(true);
    }
}
