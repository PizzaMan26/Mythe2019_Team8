using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    private int lightDamage = 15;
    private int heavyDamage = 30;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnTriggerEnter2D(Collider2D col)
    {
        int curAttack = GetComponentInParent<StartAttack>().curAttack;
        if (col.tag == "Hitbox" && curAttack == 1)
        {
            col.SendMessage("DealDamage", lightDamage);
            
        }

        if (col.tag == "Hitbox" && curAttack == 2)
        {
            col.SendMessage("DealDamage", heavyDamage);
        }
    }
}
