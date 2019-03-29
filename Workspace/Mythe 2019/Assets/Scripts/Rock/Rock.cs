using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public int damage = 0;
    public int damageToEnemy = 0;
    public int bounceForce = 0;
    public float lifeTime = 10f;

    private ParticleSystem Particle;
    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        Particle = GetComponentInChildren<ParticleSystem>();
    }

    void Update()//Timer until it breaks
    {
        lifeTime = lifeTime - Time.deltaTime;
        if (lifeTime <= 0)
        {
            Break();
        }
    }

    private void OnCollisionEnter2D(Collision2D col)//checks what it hits and acts accordingly
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

    private void Bounce()//bounces up enemies
    {
        _rb.AddForce(transform.up * bounceForce);
        Destroy(GetComponent<CircleCollider2D>());
        Particle.Play();
    }

    private void Break()//Destroyes the rock
    {
        Destroy(gameObject);
    }

    private void Bonk(GameObject col, int dam)//sends damage to the hit GameObject
    {
        col.GetComponent<Health>().DealDamage(dam);
    }
}
