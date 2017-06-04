using UnityEngine;
using System.Collections;
using System;

public class HexGrid : MonoBehaviour
{
    public GameObject hexPrefab;

    //number of hexes
    int width = 3;
    int height = 5;
    float offsetY = -43f;
    float positionOffset = 120f;

    void Start()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {

                GameObject hex = Instantiate(hexPrefab, new Vector2(x,y), Quaternion.identity);
                hex.transform.SetParent(gameObject.transform,false);
                float hw = hex.GetComponent<RectTransform>().rect.width;
                float hy = hex.GetComponent<RectTransform>().rect.width;
                float offsetX = 0f;
                if (y % 2 == 0)
                {
                    offsetX = 56.25f;
                }
                hex.GetComponent<RectTransform>().anchoredPosition = new Vector2((hw) * (x*1.5f)+ offsetX +positionOffset, (hy + offsetY) * (y) +positionOffset);
                hex.name = "Hex_" + x + "_" + y;
                if (x == 2)
                {
                    if (y % 2 == 0)
                    {
                        Destroy(hex);
                    }
                }
                //Debug.Log(hex.GetComponent<RectTransform>().anchoredPosition);
                //Debug.Log("Hex_" + x + "_" + y + "=" + (hw + offsetX) * (x + 1) +" "+ (hy + offsetY) * (y + 1));
            }
        }

    }
    void Update()
    {
        
    }
}