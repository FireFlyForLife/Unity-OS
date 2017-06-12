using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI.Extensions;
using UnityEngine.UI;
using System;

public enum Sides
{
    UP,
    TOP_RIGHT,
    BOTTOM_RIGHT,
    BOTTOM,
    BOTTOM_LEFT,
    TOP_LEFT
}
[System.Serializable]
public struct Point
{
    public int x;
    public int y;

    public static Point Empty = new Point(0, 0);

    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}

public static class SidesExtensions
{
    public static Sides Inverted(this Sides side)
    {
        switch (side)
        {
            case Sides.UP:
                return Sides.BOTTOM;
            case Sides.TOP_RIGHT:
                return Sides.BOTTOM_LEFT;
            case Sides.BOTTOM_RIGHT:
                return Sides.TOP_LEFT;
            case Sides.BOTTOM:
                return Sides.UP;
            case Sides.BOTTOM_LEFT:
                return Sides.TOP_RIGHT;
            case Sides.TOP_LEFT:
                return Sides.BOTTOM_RIGHT;
            default:
                return side;
        }
    }

    //hexouter[0] = grid.hexagons[x, y + 2]; //hex_up
    //hexouter[3] = grid.hexagons[x, y - 2]; //hex_down
    //hexouter[5] = grid.hexagons[x, y + 1]; //hex_left_up
    //hexouter[4] = grid.hexagons[x, y - 1]; //hex_left_down
    //hexouter[1] = grid.hexagons[x + 1, y + 1]; //hex_right_up
    //hexouter[2] = grid.hexagons[x + 1, y - 1]; //hex_right_down
    public static Point Direction(this Sides side, int y)
    {
        if (side == Sides.UP)
            return new Point(0, 2);
        if (side == Sides.BOTTOM)
            return new Point(0, -2);

        if (y % 2 == 0) //even
        {
            switch (side)
            {
                case Sides.TOP_RIGHT:
                    return new Point(1, 1);
                case Sides.BOTTOM_RIGHT:
                    return new Point(1, -1);
                case Sides.BOTTOM_LEFT:
                    return new Point(0, -1);
                case Sides.TOP_LEFT:
                    return new Point(0, 1);
                default:
                    return Point.Empty;
            }
        }
        else //uneven
        {
            switch (side)
            {
                case Sides.TOP_RIGHT:
                    return new Point(0, 1);
                case Sides.BOTTOM_RIGHT:
                    return new Point(0, -1);
                case Sides.BOTTOM_LEFT:
                    return new Point(-1, -1);
                case Sides.TOP_LEFT:
                    return new Point(-1, 1);
                default:
                    return Point.Empty;
            }
        }
    }
}



public class HexLogic : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler {

    public bool[] sides = new bool[6];
    public HexGrid grid;
    public int x;
    public int y;
    public bool Active {
        get { return active; }
        set {
            active = value;
            if (active)
            {
                transform.GetComponentInChildren<UILineRenderer>().color = Color.red;
                CheckSides();
            } else
            {
                transform.GetComponentInChildren<UILineRenderer>().color = Color.white;
            }
            
        }
    }
    [SerializeField] private bool active;
    private float[] lineLocations_x = new float[] { 0.5f, 1, 1, 0.5f, 0, 0 };
    private float[] lineLocations_y = new float[] { 1, 0.84f, 0.16f, 0, 0.16f, 0.84f };
    // Use this for initialization
    void Start () {
        DrawSides();
    }
    public void DrawSides()
    {
        int points = 0;
        for (int i = 0; i < sides.Length; i++)
        {
            if (sides[i]) {
                transform.GetComponentInChildren<UILineRenderer>().Points[i*2] = new Vector2(lineLocations_x[i], lineLocations_y[i]);
            }
        }
        points = points * 2;
    }
    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        
        transform.GetChild(0).transform.Rotate(0, 0, -60, Space.World);
        sides = ShiftRight(sides);

        grid.Refresh();
    }

    // Update is called once per frame
    void Update () {
    }
    public void CheckSides()
    {

        for (int i = 0; i < sides.Length; i++)
        {
            if (sides[i]) {
                Sides side = (Sides)i;
                Point dir = side.Direction(y);

                HexLogic hex = grid.At(x + dir.x, y + dir.y);
                Sides invertedSide = side.Inverted();
                int invertedSideIndex = (int)invertedSide;

                if (hex && !hex.Active && hex.sides[invertedSideIndex])
                {
                    hex.Active = true;
                }
            }
        }
     }
        private bool[] ShiftRight(bool[] sides)
        {
            bool[] shiftarr = new bool[sides.Length];

            for (int i = 1; i < sides.Length; i++)
            {
                shiftarr[i] = sides[i - 1];
            }

            shiftarr[0] = sides[shiftarr.Length - 1];

            return shiftarr;
        }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponentInChildren<Image>().color = new Color(0.9f,0.9f,0.9f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponentInChildren<Image>().color = Color.white;
    }
}
