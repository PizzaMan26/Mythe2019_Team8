using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float Lforce = 0;//light attack force
    public float Hforce = 0;//heavy attack force

    private int _lightDamage = 15;
    private int _heavyDamage = 30;


    private void OnTriggerEnter2D(Collider2D col)//send attack to the object that got hit
    {
        int curAttack = GetComponentInParent<StartAttack>().curAttack;
        if (col.tag == "Enemy" && curAttack == 1)
        {
            col.GetComponent<Health>().Juggle(Lforce);
            col.GetComponent<Health>().DealDamage(_lightDamage);
        }

        if (col.tag == "Enemy" && curAttack == 2)
        {
            col.GetComponent<Health>().OnHit(Hforce);
            col.GetComponent<Health>().DealDamage(_heavyDamage);
        }
    }
}
