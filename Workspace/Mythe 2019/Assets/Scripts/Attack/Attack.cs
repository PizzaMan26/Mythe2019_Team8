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
        if (col.tag == "Hitbox" && curAttack == 1)
        {
            col.SendMessage("DealDamage", _lightDamage);
            col.gameObject.SendMessage("Juggle", Lforce);
        }

        if (col.tag == "Hitbox" && curAttack == 2)
        {
            col.SendMessage("DealDamage", _heavyDamage);
            col.gameObject.SendMessage("OnHit",Hforce);
        }
    }
}
