using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public int damage = 0;
    public int damageToEnemy = 0;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground" )
        {
            Break();
        }
        if (col.gameObject.tag == "Player")
        {
            Bonk(col.gameObject, damage);
            Break();
        }
        if (col.gameObject.tag == "Enemy")
        {
            Bonk(col.gameObject, damageToEnemy);
            Break();
        }
    }

    private void Break()
    {
        Destroy(gameObject);
    }

    private void Bonk(GameObject col, int dam)
    {
        col.GetComponent<Health>().DealDamage(dam);
    }
}
