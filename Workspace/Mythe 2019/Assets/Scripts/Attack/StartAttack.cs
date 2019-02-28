using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAttack : MonoBehaviour
{
    private GameObject AttackBox;
    private float lightCD = 0.3f;
    private float heavyCD = 0.9f;
    private float curCD = 0f;

    [HideInInspector]
    public int curAttack = 0;
    //0 = none
    //1 = light
    //2 = heavy

    // Start is called before the first frame update
    void Start()
    {
        AttackBox = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (curCD <= 0 && Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("kaas");
            LightAttack();
            curCD = lightCD;
            curAttack = 1;
        }

        if (curCD <= 0 && Input.GetKeyDown(KeyCode.Mouse1))
        {
            Debug.Log("spagetti cheese");
            HeavyAttack();
            curCD = heavyCD;
            curAttack = 2;
        }


        if (curCD > 0)
        {
            curCD = curCD - Time.deltaTime;
            if (AttackBox.activeSelf && curCD <= 0.2f)
            {
                AttackBox.SetActive(false);
                curAttack = 0;
            }
        }
    }


    private void LightAttack()
    {
        AttackBox.SetActive(true);
    }

    private void HeavyAttack()
    {
        AttackBox.SetActive(true);
    }
}
