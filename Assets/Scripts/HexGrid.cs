using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

public class HexGrid : MonoBehaviour
{
    public GameObject hexPrefab;

    //number of hexes
    int width = 3;
    int height = 5;
    float offsetY = -43f;
    public Vector2 PositionOffset = new Vector2(120f, 0f);
    public string json;
    public List<GameObject> hexagons;
    public GameObject hexagonInfo;
    public Texture2D[] lines;
    private JSONObject jsonObject;

    void Start()
    {
        
        Debug.Log(Environment.Version);
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {

                GameObject hex = Instantiate(hexPrefab, Vector3.zero, Quaternion.identity);
                hex.transform.SetParent(gameObject.transform,false);
                float hw = hex.GetComponent<RectTransform>().rect.width;
                float hy = hex.GetComponent<RectTransform>().rect.height;

                Debug.Log(hw.ToString() + ":" + hy.ToString());

                float offsetX = 0f;
                if (y % 2 == 0)
                {
                    offsetX = hw * 0.75f;
                }
                hex.GetComponent<RectTransform>().anchoredPosition = new Vector2(hw * x * 1.5f + offsetX + PositionOffset.x, hy * y * 0.5f + offsetY + PositionOffset.y);
                hex.name = "Hex_" + x + "_" + y;
                hex.transform.GetComponent<HexLogic>().x = x;
                hex.transform.GetComponent<HexLogic>().y = y;
                hexagons.Add(hex.transform.GetChild(0).gameObject);
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
        populateFromJson();
    }
    private void populateFromJson()
    {
        jsonObject = new JSONObject(JSONObject.Type.ARRAY);
        jsonObject = new JSONObject(json);

        foreach (JSONObject j in jsonObject.list)
        {
            long id = j.GetField("id").i;
            long x = j.GetField("x").i;
            long y = j.GetField("y").i;
            long rotation = j.GetField("rotation").i;

            switch (id)
            {
                case 0:
                    //lines[0];
                    break;
            }

            Debug.Log(id + " " + x + " " + y + " " + rotation);
        }
    }
    void Update()
    {
        
    }
}