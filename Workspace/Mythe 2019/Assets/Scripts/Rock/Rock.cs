using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public int damage = 0;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground" || col.gameObject.tag == "Enemy")
        {
            Break();
        }
        if (col.gameObject.tag == "Player")
        {
            BonkPlayer(col.gameObject);
            Break();
        }
    }

    private void Break()
    {
        Destroy(gameObject);
    }

    private void BonkPlayer(GameObject col)
    {
        col.GetComponent<Health>().DealDamage(damage);
    }
}
