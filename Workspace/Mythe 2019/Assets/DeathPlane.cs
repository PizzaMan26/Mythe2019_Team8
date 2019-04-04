using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlane : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            print("jojo");
            Health PH = collision.GetComponent<Health>();
            PH.DealDamage(10000000);
        }
    }
}
