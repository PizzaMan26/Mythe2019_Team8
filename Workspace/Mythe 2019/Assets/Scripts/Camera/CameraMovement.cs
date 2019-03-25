using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject target;

    void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        Vector3 pos = new Vector3(target.transform.position.x, transform.position.y, transform.position.z);

        transform.position = Vector3.MoveTowards(transform.position, pos, 1f);

        
    }

    /*private void CheckForPlatform()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.up);

        if (hit.collider.tag == "Ground")
        {
            Debug.Log("er is kaas");
        }
    }
    */
}
