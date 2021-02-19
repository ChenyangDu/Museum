using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform Pos;
    public Transform Plane;

    public bool ADon = false;
    private float rotateSpeed = 2f;

    private void Awake()
    {
        //Pos.transform.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos;
        Vector3 CamInPos = Pos.transform.InverseTransformPoint(transform.position); // 摄像机在飞机中的局部坐标；
        
        targetPos.x = Mathf.Lerp(CamInPos.x, 0, 6f * Time.deltaTime);
        targetPos.y = Mathf.Lerp(CamInPos.y, 0, 6f * Time.deltaTime);
        targetPos.z = Mathf.Lerp(CamInPos.z, 0, 6f * Time.deltaTime);

        transform.position = Pos.transform.TransformPoint(targetPos);

        rotateSpeed = Mathf.Lerp(rotateSpeed, (ADon ? 2f : 10f), 2*Time.deltaTime);
        
        transform.rotation = Quaternion.Lerp(transform.rotation, Pos.rotation, rotateSpeed * Time.deltaTime);
    }
}
