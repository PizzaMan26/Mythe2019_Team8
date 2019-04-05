using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsOnGround : MonoBehaviour
{
    [SerializeField]private LayerMask ground;

    public string CheckOnGround(Transform trans, float adjustDown)
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector3(trans.position.x, trans.position.y - adjustDown, trans.position.z), trans.TransformDirection(Vector3.down), .3f);
        Debug.DrawRay(new Vector3(trans.position.x, trans.position.y - adjustDown, trans.position.z), trans.TransformDirection(Vector3.down) * .3f, Color.green);
        if (hit.collider != null)//check the raycast hits anything if it does it will return the string of the tag hit
        {
            print(hit.collider.gameObject.tag);
            return (hit.collider.gameObject.tag);
        }
        else //when the raycast doesn't hit anything it will return null
        {
            return (null);
        }
    }
}
