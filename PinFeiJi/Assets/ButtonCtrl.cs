using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCtrl : MonoBehaviour
{
    
    public GameObject planeGO;
    public Transform content;

    private Plane plane;
    private GameObject buttonPrefab;

    private void Awake()
    {
        buttonPrefab = Resources.Load("Part/Prefab/button") as GameObject;
        plane = planeGO.AddComponent<Plane>();
    }

    private void Start()
    {
        foreach(Part part in plane.GetParts())
        {
            // 创建按钮
            GameObject button = Instantiate(buttonPrefab,content);

            // 设置图片
            string name = part.transform.name;
            Texture2D texture = Resources.Load("Part/" + name) as Texture2D;
            if(texture == null)
            {
                texture = Resources.Load("Part/None") as Texture2D;
            }
            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
            button.GetComponent<Image>().sprite = sprite;

            // 设置相关脚本
            ButtonPart buttonPart = button.GetComponent<ButtonPart>();
            buttonPart.part = part;
            part.buttonPart = buttonPart;
        }
    }
}
