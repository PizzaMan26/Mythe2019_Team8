using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private GameObject CheckpointManager;

    private bool hasReached = false;

    void Start()
    {
        CheckpointManager = GameObject.FindGameObjectWithTag("CheckpointManager");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && !hasReached)
        {
            hasReached = true;
            SetProgress();
        }
    }

    private void SetProgress()
    {
        CheckpointManager.GetComponent<CheckpointManager>().SetProgress(1);
    }
}
