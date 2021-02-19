using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part : MonoBehaviour
{
    public ButtonPart buttonPart;
    public PartHight partHight;

    private Vector3 TargetPos;
    private bool isMouseFollow = false;
    private bool isNearTar = false;
    private MeshRenderer[] childs;

    void Awake()
    {
        TargetPos = transform.position;
        childs = transform.GetComponentsInChildren<MeshRenderer>();
    }

    private void Start()
    {
        SetVisiable(false);
    }

    void Update()
    {
        if (isMouseFollow)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out RaycastHit hit, 100);
            if (hit.transform != null)
            {
                Vector3 pos = hit.point;
                pos.y = TargetPos.y;
                transform.position = pos;
                isNearTar = (transform.position - TargetPos).magnitude < 1f;
                if (isNearTar)
                {
                    partHight.HilightSet(false); // 关闭高亮
                    transform.position = TargetPos;
                }
                else
                {
                    partHight.HilightSet(true); // 打开高亮
                }
            }
            if (Input.GetMouseButtonDown(0))
            {
                MouseFollow(false);
            }
        }
    }

    private void SetVisiable(bool isOn)
    {
        foreach(var child in childs)
        {
            child.enabled = isOn;
        }
    }

    // 开启、关闭跟随鼠标
    public void MouseFollow(bool isOn)
    {
        if (isOn)
        {
            isMouseFollow = true;
            SetVisiable(true);
        }
        else
        {
            isMouseFollow = false;
            if (isNearTar)
            {
                partHight.HilightSet(false); // 关闭高亮
                transform.position = TargetPos;
                Destroy(buttonPart.gameObject);
            }
            else
            {
                partHight.HilightSet(true); // 打开高亮
                SetVisiable(false);
            }
        }
    }

}
