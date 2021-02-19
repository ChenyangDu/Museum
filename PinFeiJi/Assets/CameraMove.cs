using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform plane;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(2))
        {
            transform.RotateAround(plane.position, Vector3.up, Input.GetAxis("Mouse X"));
            transform.RotateAround(plane.position, transform.right, -Input.GetAxis("Mouse Y"));
        }
    }
}
