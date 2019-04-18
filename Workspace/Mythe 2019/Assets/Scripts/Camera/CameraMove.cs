using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

	public Transform target;

	public float smoothSpeed;
	public Vector3 offset;

	void Update ()
	{
		transform.position = Vector3.Lerp(transform.position, target.position + offset, smoothSpeed * Time.deltaTime);
	}
}
