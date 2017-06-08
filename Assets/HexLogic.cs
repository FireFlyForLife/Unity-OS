using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HexLogic : MonoBehaviour, ISelectHandler, IPointerClickHandler {

    public bool[] sides = new bool[6];
    public int x;
    public int y;
    public bool active;
	// Use this for initialization
	void Start () {
		
	}
    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        
        gameObject.transform.Rotate(0, 0, 60, Space.World);
        sides = ShiftRight(sides);
    }
    void ISelectHandler.OnSelect(BaseEventData eventData)
    {
        Debug.Log("clicked");
    }

    // Update is called once per frame
    void Update () {
    }
    void CheckSides()
    {
        if (GameObject.Find("Hex_" + x + "_" + (y + 2)).transform.GetComponent<HexLogic>().active)
        {
            GameObject hex_up = GameObject.Find("Hex_" + x + "_" + (y + 2));
            GameObject hex_down = GameObject.Find("Hex_" + x + "_" + (y - 2));
            GameObject hex_left_up = GameObject.Find("Hex_" + x + "_" + (y + 1));
            GameObject hex_left_down = GameObject.Find("Hex_" + x + "_" + (y - 1));
            GameObject hex_right_up = GameObject.Find("Hex_" + (x + 1) + "_" + (y + 1));
            GameObject hex_right_down = GameObject.Find("Hex_" + (x + 1) + "_" + (y - 1));

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
}
