using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private GameObject CheckpointManager;
    Vector3 Position;

    [SerializeField]
    private int side;

    private bool hasReached = false;

    void Start()
    {
        CheckpointManager = GameObject.FindGameObjectWithTag("CheckpointManager");
        Position = new Vector3(transform.position.x,transform.position.y+1,transform.position.z);
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
        CheckpointManager.GetComponent<CheckpointManager>().SetProgress(1, Position);
    }

    public int GetSide()
    {
        return side;
    }

    public Vector3 GetPos()
    {
        return Position;
    }
}
