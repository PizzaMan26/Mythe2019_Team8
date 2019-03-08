using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{ 

    public GameObject target;



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

    private float _enemySpeed = 4f;
    private int _enemyLayer = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckForPlayer()
    {

        if (_enemyLayer == 0)
        {
            Vector3 pos = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);

            transform.position = Vector3.MoveTowards(transform.position, pos, .05f);
        }

    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            CheckForPlayer();
        }
    }

}
