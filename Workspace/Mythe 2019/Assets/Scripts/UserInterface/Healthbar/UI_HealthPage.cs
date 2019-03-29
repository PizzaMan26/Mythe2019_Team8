using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_HealthPage : MonoBehaviour
{
    [SerializeField]
    private float destroyTime, moveTime;
    [SerializeField]
    private Vector2 speed, position;

    private float timer = 0;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > moveTime) Move();
        if (timer > destroyTime) Destroy(gameObject);
    }

    private void Move()
    {
        position.x += speed.x;
        position.y -= speed.y;
        transform.position = position;
    }
}
