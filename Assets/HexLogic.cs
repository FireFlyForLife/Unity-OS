using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HexLogic : MonoBehaviour, ISelectHandler, IPointerClickHandler {

    public bool[] sides = new bool[6];
	// Use this for initialization
	void Start () {
		
	}
    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("clicked");
        gameObject.transform.Rotate(0, 0, 60, Space.World);
        ShiftRight(sides);
    }
    void ISelectHandler.OnSelect(BaseEventData eventData)
    {
        Debug.Log("clicked");
    }

    // Update is called once per frame
    void Update () {
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
