using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private int _health = 100;

    public void DealDamage(int damage)//deals damage to object
    {
        _health = _health - damage;

        if(_health <= 0)//wasted
        {
            Debug.Log("RIP in perpperonies");
        }
    }

    
}
