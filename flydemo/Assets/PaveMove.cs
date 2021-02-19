using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaveMove : MonoBehaviour
{
    public float speed = 5f;
    float y_min;
    float y_max;

    // Start is called before the first frame update
    void Start()
    {
        y_min = transform.position.y;
        y_max = y_min + 8;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && transform.position.y < y_max)
        {
            transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
        }
        if (Input.GetMouseButton(1)&&transform.position.y>y_min)
        {
            transform.Translate(new Vector3(0, 0, -speed * Time.deltaTime));
        }
    }
}
