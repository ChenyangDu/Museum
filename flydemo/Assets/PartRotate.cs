using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartRotate : MonoBehaviour
{
    private Vector3 oriRotation;
    public Vector3 pivot;

    private void Awake()
    {
        oriRotation = transform.localEulerAngles;
    }

    public void Rotate(float axios)
    {
        if (axios == 0) return;
        transform.localEulerAngles = oriRotation + pivot * axios;
    }
}
