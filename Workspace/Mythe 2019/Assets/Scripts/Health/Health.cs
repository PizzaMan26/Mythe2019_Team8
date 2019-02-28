using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private int _health = 100;

    public void DealDamage(int damage)
    {
        _health = _health - damage;
        Debug.Log("oof " + damage);

        if(_health <= 0)
        {
            Debug.Log("RIP in perpperonies");
        }
    }

    
}
