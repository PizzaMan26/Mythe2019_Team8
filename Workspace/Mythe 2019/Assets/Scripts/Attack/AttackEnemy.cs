using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemy : MonoBehaviour
{
    [SerializeField]
    private int damage = 0;

    private void OnTriggerEnter2D(Collider2D col)//send attack to the object that got hit
    {
        if (col.tag == "Player")
        {
            col.SendMessage("DealDamage", damage);
        }
    }
}
