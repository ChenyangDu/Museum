using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartHight : MonoBehaviour
{
    protected HighlightableObject ho;
    private Material transprtMat; // 一种透明材质
    private bool isOn; // 当前高亮状态
    private MeshRenderer[] meshRenderers;
    private void Awake()
    {
        ho = gameObject.AddComponent<HighlightableObject>();
        ho.ConstantOn(Color.green);
        isOn = true;
        transprtMat = Resources.Load("Part/Alpha") as Material;
        meshRenderers = GetComponentsInChildren<MeshRenderer>();
        foreach (var mesh in meshRenderers)
        {
            mesh.materials = new Material[] { transprtMat };
        }
    }
    private void Start()
    {
        ho.ConstantOn();
    }

    public void HilightSet(bool setOn)
    {
        if(setOn != isOn)
        {
            isOn = setOn;
            foreach (var mesh in meshRenderers)
            {
                mesh.enabled = setOn;
            }
        }
    }
}
