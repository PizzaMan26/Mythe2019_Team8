using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAttack : MonoBehaviour
{
    private GameObject _AttackBox;
    private GameObject GameManager;
    private Rigidbody2D rb;
    private float _lightCD = 0.3f;
    private float _heavyCD = 0.5f;
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
        GameManager = GameObject.Find("GameManager");
        _AttackBox = transform.GetChild(0).gameObject;//get's the attack hitbox
        rb = GetComponent<Rigidbody2D>();//get's the rigidbody

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
            if (GetComponent<IsOnGround>().CheckOnGround(transform, 3f) != "Ground")
            {
                rb.velocity = new Vector2(0, 5);
            }
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
