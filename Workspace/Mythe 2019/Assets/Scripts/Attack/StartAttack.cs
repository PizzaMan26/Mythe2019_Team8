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

    private InputHandler inputHandler;

    void Start()
    {
        _AttackBox = transform.GetChild(0).gameObject;//get's the attack hitbox

        inputHandler = GameObject.FindWithTag("InputHandler").GetComponent<InputHandler>();
        //delicate's from the inputHandler
        inputHandler.Attack1 += LightAttack;
        inputHandler.Attack2 += HeavyAttack;

    }


    void Update()
    {

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

    
    private void LightAttack()//Light attack
    {
        if (curCD <= 0)
        {
            curCD = _lightCD;
            curAttack = 1;
            _AttackBox.SetActive(true);//enables attack hitbox
        }
        
    }
    private void HeavyAttack()//Heavy attack
    {
        
        if (curCD <= 0)
        {           
            curCD = _heavyCD;
            curAttack = 2;
            _AttackBox.SetActive(true);//enables attack hitbox
        }
    }


   
}
