using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public int damage = 0;
    public int damageToEnemy = 0;
    public int bounceForce = 0;
    public float lifeTime = 10f;


    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        lifeTime = lifeTime - Time.deltaTime;
        if (lifeTime <= 0)
        {
            Break();
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            Bounce();
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

    private void Bounce()
    {
        _rb.AddForce(transform.up * bounceForce);
        Destroy(GetComponent<CircleCollider2D>());
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
