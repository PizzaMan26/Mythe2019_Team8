using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private Health health;

    public Camera mainCam;

    float shakeAmt = 0;

    void Awake()
    {
        health = GameObject.Find("Player").GetComponent<Health>();
        health.playerHit += GetHit;

        if (mainCam == null)
        {
            mainCam = Camera.main;
        }
    }

    private void GetHit(int amount)
    { 
        Shake(1f, 0.8f);
    }

    public void Shake(float amt, float lenght)
    {
        shakeAmt = amt;
        InvokeRepeating("BeginShake", 0, 0.1f);
        Invoke("StopShake", lenght);
    }

    void BeginShake()
    {
        if (shakeAmt > 0)
        {
            Vector3 camPos = mainCam.transform.position;

            float offsetX = Random.value * shakeAmt * 2 - shakeAmt;
            float offsetY = Random.value * shakeAmt * 2 - shakeAmt;
            camPos.x += offsetX;
            camPos.y += offsetY;

            mainCam.transform.position = camPos;
        }
    }

    void StopShake()
    {
        CancelInvoke("BeginShake");
        mainCam.transform.localPosition = Vector3.zero;
    }
}