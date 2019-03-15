using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRock : MonoBehaviour
{
    public GameObject Rock;//rock
    public GameObject PointA;
    public GameObject PointB;//points to spawn rocks between, A always has to be left of B;

    public float spawnSpeed = 0;//time between spawns of the rocks
    private float rockTimer = 0;//time until a rock spawns

    void Update()
    {
        DropRock();
    }

    private void DropRock()
    {
        if (rockTimer <= 0)//spawns rock and resets timer to spawnspeed
        {
            float x = Random.Range(PointA.transform.position.x, PointB.transform.position.x);
            Instantiate(Rock, new Vector3(x, transform.position.y, 0), Quaternion.identity);
            rockTimer = spawnSpeed;
        }
        else if (rockTimer >= 0)//counts down
        {
            rockTimer = rockTimer - Time.deltaTime;
        }
    }
}
