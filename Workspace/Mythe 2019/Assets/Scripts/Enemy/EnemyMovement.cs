using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private TestPlayerMovement tpm = new TestPlayerMovement();

    public GameObject target;

    private float _enemySpeed = 4f;
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
    void Start()
    {

    }

    void Update()
    {
        CheckForPlayer();
    }

    public void CheckForPlayer()
    {
        if(_enemyLayer == tpm.getLayer)
        {
            Vector3 pos = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);

            transform.position = Vector3.MoveTowards(transform.position, pos, .05f);
        }
    }
}
