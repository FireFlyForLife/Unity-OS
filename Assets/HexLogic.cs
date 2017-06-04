using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HexLogic : MonoBehaviour, ISelectHandler, IPointerClickHandler {

	// Use this for initialization
	void Start () {
		
	}
    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("clicked");
    }
    void ISelectHandler.OnSelect(BaseEventData eventData)
    {
        Debug.Log("clicked");
    }

    // Update is called once per frame
    void Update () {
    }
}
