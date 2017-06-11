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
    public HexLogic[,] hexagons;
    public GameObject hexagonInfo;
    public Texture2D[] lines;
    private JSONObject jsonObject;
    
    public Point Begin = new Point(0, 3);
    public Sides BeginSide = Sides.UP;

    public Point End = new Point(2, 1);
    public Sides EndSide = Sides.BOTTOM;
    public Image EndLine;

    void Start()
    {
        hexagons = new HexLogic[width,height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {

                GameObject hex = Instantiate(hexPrefab, Vector3.zero, Quaternion.identity);
                hex.transform.SetParent(gameObject.transform,false);
                float hw = hex.GetComponent<RectTransform>().rect.width;
                float hy = hex.GetComponent<RectTransform>().rect.height;

                float offsetX = 0f;
                if (y % 2 == 0)
                {
                    offsetX = hw * 0.75f;
                }
                hex.GetComponent<RectTransform>().anchoredPosition = new Vector2(hw * x * 1.5f + offsetX + PositionOffset.x, hy * y * 0.5f + offsetY + PositionOffset.y);
                hex.name = "Hex_" + x + "_" + y;
                hex.transform.GetComponent<HexLogic>().x = x;
                hex.transform.GetComponent<HexLogic>().y = y;
                hexagons[x, y] = hex.GetComponent<HexLogic>();
                hex.GetComponent<HexLogic>().grid = this;
                if (x == 2)
                {
                    if (y % 2 == 0)
                    {
                        Destroy(hex);
                    }
                }
                Debug.Log(hexagons[x, y]);
            }
        }
        populateFromJson();

        Refresh();
    }
    private void populateFromJson()
    {
        jsonObject = new JSONObject(JSONObject.Type.ARRAY);
        jsonObject = new JSONObject(json);

        foreach (JSONObject j in jsonObject.list)
        {
            List<JSONObject> sides = j.GetField("sides").list;
            long x = j.GetField("x").i;
            long y = j.GetField("y").i;
            HexLogic hex = hexagons[x, y];


            for (int i = 0; i < sides.Count; i++)
            {
                bool side = Convert.ToBoolean(sides[i].i);
                hex.sides[i] = side;
            }
            hex.DrawSides();
            //hex.CheckSides();
            //if (hex.x == 2)
            //{
            //    if (hex.y == 0 || hex.y == 2 || hex.y == 4)
            //    {
            //        //Destroy(hex);
            //    }
            //}
        }
        
    }

    public void Refresh()
    {
        //Clear everything
        EndLine.color = Color.white;

        for (int x = 0; x < hexagons.GetLength(0); x++)
        {
            for (int y = 0; y < hexagons.GetLength(1); y++)
            {
                HexLogic hex = At(x, y);
                if (hex)
                {
                    hex.Active = false;
                }
            }
        }

        //Check the begin hex
        HexLogic beginHex = At(Begin.x, Begin.y);
        int beginSideIndex = (int)BeginSide;
        if (beginHex.sides[beginSideIndex])
        {
            beginHex.Active = true;
        }

        HexLogic endHex = At(End.x, End.y);
        int EndSideIndex = (int)EndSide;
        if (endHex.sides[EndSideIndex] && endHex.Active)
        {
            Debug.Log("HOERA");
            EndLine.color = Color.red;
        }
    }

    public HexLogic GetNeighbor(int x, int y, Sides side)
    {
        throw new NotImplementedException("fuck off");
    }

    public List<HexLogic> GetNeighbors(int x, int y)
    {
        Point[] localCoords = new Point[] { new Point(0, 2), new Point(0, -2),
            new Point(0, 1), new Point(0, -1), new Point(1, 1), new Point(1, -1)
        };

        List<HexLogic> ret = new List<HexLogic>();

        foreach (Point p in localCoords)
        {
            HexLogic hex = At(x + p.x, y + p.y);
            if (hex)
            {
                ret.Add(hex);
            }
        }

        return ret;

        //hexouter[0] = grid.hexagons[x, y + 2]; //hex_up
        //hexouter[3] = grid.hexagons[x, y - 2]; //hex_down
        //hexouter[5] = grid.hexagons[x, y + 1]; //hex_left_up
        //hexouter[4] = grid.hexagons[x, y - 1]; //hex_left_down
        //hexouter[1] = grid.hexagons[x + 1, y + 1]; //hex_right_up
        //hexouter[2] = grid.hexagons[x + 1, y - 1]; //hex_right_down
        
    }
    public HexLogic At(int x, int y)
    {
        if (x >= 0 && x < hexagons.GetLength(0) && y >= 0 && y < hexagons.GetLength(1))
        {
            return hexagons[x, y];
        }

        return null;
    }
    void Update()
    {
        LayoutRebuilder.ForceRebuildLayoutImmediate(transform as RectTransform);
    }
}