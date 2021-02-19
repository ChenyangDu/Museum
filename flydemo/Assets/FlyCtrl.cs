using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyCtrl : MonoBehaviour
{
    public GameObject HorizontalTailLeft, HorizontalTailRight;
    public GameObject VerticalTail;
    public GameObject AileronLeft, AileronRight;
    private CamFollow camFollow;

    

    private void Start()
    {
        camFollow = FindObjectOfType<CamFollow>();
    }

    private void Update()
    {
        WSCtrl();
        ADCtrl();
        QECtrl();
        Forward();
    }

    private void Forward()
    {
        transform.Translate(Vector3.forward * 0.2f*Time.deltaTime * 60f, Space.Self);
    }

    private void WSCtrl()
    {
        float angle = Input.GetAxis("Vertical");
        transform.Rotate(Vector3.right, angle * Time.deltaTime * 60f, Space.Self);

        HorizontalTailLeft.GetComponent<PartRotate>().Rotate(angle*30);
        HorizontalTailRight.GetComponent<PartRotate>().Rotate(-angle * 30);
    }
    private void ADCtrl()
    {
        float angle = Input.GetAxis("Horizontal");

        if (angle == 0)
        {
            camFollow.ADon = false;
        }
        else
        {
            camFollow.ADon = true;
        }

        transform.Rotate(-1*Vector3.forward, angle * Time.deltaTime * 120f, Space.Self);

        AileronLeft.GetComponent<PartRotate>().Rotate(-angle*30);
        AileronRight.GetComponent<PartRotate>().Rotate(-angle*30);
    }
    private void QECtrl()
    {
        float angle = Input.GetAxis("Roll");
        
        transform.Rotate(1*Vector3.up, angle * Time.deltaTime * 60f, Space.Self);

        VerticalTail.GetComponent<PartRotate>().Rotate(-angle * 30);
    }
    
}
