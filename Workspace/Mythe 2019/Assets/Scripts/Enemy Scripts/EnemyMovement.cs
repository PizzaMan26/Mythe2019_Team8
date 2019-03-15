using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject target;

    private Health _enemyHealth;
    public float _enemySpeed;
    private int _enemyLayer = 0;

    public int getEnemyLayer
    {
        get
        {
            return _enemyLayer;
        }
        set
        {
            _enemyLayer = value;
        }
    }


    public void CheckForPlayer()
    {
        if (_enemyLayer == 0)
        {
            Vector3 pos = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);

            transform.position = Vector3.MoveTowards(transform.position, pos, _enemySpeed);
        }
    }


    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            CheckForPlayer();
        }
    }


    private void RunAway()
    {

    }
}

