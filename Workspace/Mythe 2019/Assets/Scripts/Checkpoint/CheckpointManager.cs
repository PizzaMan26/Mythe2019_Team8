using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    private int progress = -1; 
    private List<Checkpoint> checkpoints = new List<Checkpoint>();
    private Vector3 Pos;

    void Start()
    {
       var CheckpointObjs = GameObject.FindGameObjectsWithTag("Checkpoint");

        for (int i = 0; i < CheckpointObjs.Length; i++)
        {
            checkpoints.Add(CheckpointObjs[i].GetComponent<Checkpoint>());
        }

    }

    public void SetProgress(int p, Vector3 pos)
    {
        progress += p;
        Pos = pos;
    }

    public int GetProgress()
    {
       return progress;
    }

    public GameObject GetCheckpoint()
    {
        return checkpoints[progress].gameObject;
    }

    public int GetCheckpointSide()
    {
        if (progress <= 0)
        {
            int s = checkpoints[progress].gameObject.GetComponent<Checkpoint>().GetSide();
            return s;
        }
        else
        {
            int s = 0;
            return s;
        }
    }

    public Vector3 GetPosition()
    {
        return Pos;
    }
}
