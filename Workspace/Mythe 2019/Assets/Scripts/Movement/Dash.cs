using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    private Rigidbody2D _rb;

    public float force = 0;
    public float cooldown = 1f;
    private float _CD;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        DashSys();
    }

    private void DashSys()
    {
        _CD -= Time.deltaTime;
        if (GetComponent<StartAttack>().curCD <= 0) {
            if (Input.GetKeyDown(KeyCode.E) && _CD <= 0)
            {
                _rb.AddForce(transform.right * force);
                _CD = cooldown;
            }
            else if (Input.GetKeyDown(KeyCode.Q) && _CD <= 0)
            {
                _rb.AddForce(transform.right * -force);
                _CD = cooldown;
            }
        }
    }
}
