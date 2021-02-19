using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPart : MonoBehaviour
{
    public Part part;
    public void Click()
    {
        part.MouseFollow(true);
    }
}
