using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    public Transform target;
    private Vector3 finalTarget;

    public float smoothSpeed;
    public Vector3 offset;

    void Update()
    {
        finalTarget = target.position;
        if (finalTarget.y < -30)
        {
            finalTarget = new Vector3(finalTarget.x, -30, finalTarget.z);
        }
        transform.position = Vector3.Lerp(transform.position, finalTarget + offset, smoothSpeed * Time.deltaTime);
    }
}