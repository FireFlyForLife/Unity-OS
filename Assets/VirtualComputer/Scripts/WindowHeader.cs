using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WindowHeader : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	Vector2 offset = Vector2.zero;
    private Transform parent;

    void Start()
    {
        parent = transform.parent;
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        transform.parent.SetAsLastSibling();
        offset = (Vector2)parent.transform.position - eventData.position;
    }

    //TODO: Make this drag a box around and not directly move the window
    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        parent.transform.position = eventData.position + offset;
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        offset = Vector2.zero;
    }
}
