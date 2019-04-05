using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    private int Progress = -1; 
    private List<Checkpoint> checkpoints = new List<Checkpoint>();

    void Start()
    {
       var CheckpointObjs = GameObject.FindGameObjectsWithTag("Checkpoint");

        for (int i = 0; i < CheckpointObjs.Length; i++)
        {
            checkpoints.Add(CheckpointObjs[i].GetComponent<Checkpoint>());
        }

    }

    public void SetProgress(int p)
    {
        Progress += p;
    }

    public int GetProgress()
    {
       return Progress;
    }

    public Checkpoint GetCheckpoint()
    {
        return checkpoints[Progress];
    }
}
