using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{

    private List<Part> parts = new List<Part>();

    // Start is called before the first frame update
    void Awake()
    {
        foreach (Transform child in transform)
        {
            // 外发光
            GameObject clone = Instantiate(child.gameObject,child.position,child.rotation);
           
            Part part = child.gameObject.AddComponent<Part>();
            part.partHight = clone.AddComponent<PartHight>();
            parts.Add(part);
        }

    }

    private void Start()
    {
       
    }



    public List<Part> GetParts()
    {
        return parts;
    }
}
