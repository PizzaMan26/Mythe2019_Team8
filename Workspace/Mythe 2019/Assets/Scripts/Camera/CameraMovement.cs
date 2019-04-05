using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject target;
    [SerializeField] private Tower_Switch_Sides _tower;
    private Vector3 _pos;
    private bool updatingY = false;
    // Start is called before the first frame update
    void Start()
    {
        _tower = GameObject.Find("Tower").GetComponent<Tower_Switch_Sides>();
        _tower.goUp += UpdateY;
        _tower.goDown += UpdateY;
    }

    void Update()
    {
        if (!updatingY)
        {
            FollowPlayer();
        }
        
    }

    private void FollowPlayer()
    {
         _pos = new Vector3(target.transform.position.x, transform.position.y, transform.position.z);

        transform.position = Vector3.MoveTowards(transform.position, _pos, 1f);

        
    }

    private void UpdateY()
    {
        float offset = 10;
        updatingY = true;
        print("!");
        _pos = new Vector3(target.transform.position.x, target.transform.position.y+offset,transform.position.z);
        while (updatingY)
        {
            transform.position = Vector3.MoveTowards(transform.position, _pos, 1f);
            if (transform.position == _pos)
                updatingY = false;
        }
    }
}
