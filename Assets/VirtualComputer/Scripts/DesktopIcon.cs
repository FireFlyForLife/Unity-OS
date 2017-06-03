using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[Serializable]
public class IconSettings
{
    public Texture Icon;
    public String Text = "Program.exe";
}

public class DesktopIcon : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] Color selectedColor;
    [SerializeField] RawImage underTextImage;
    [SerializeField] RawImage Icon;
    [SerializeField] Text Text;

    [SerializeField]
    IconSettings icon;

    private Vector2 dragOffset = Vector2.zero;

	void Start ()
	{
	    Icon.texture = icon.Icon;
	    Text.text = icon.Text;
	}
	
	void Update () {
		
	}

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        Icon.gameObject.GetComponent<CanvasRenderer>().SetAlpha(0.8f);
        Icon.gameObject.GetComponent<CanvasRenderer>().SetColor(selectedColor);

        underTextImage.enabled = true;

        dragOffset = (Vector2)transform.position - eventData.position;
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position + dragOffset;
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        Icon.gameObject.GetComponent<CanvasRenderer>().SetAlpha(1f);
        Icon.gameObject.GetComponent<CanvasRenderer>().SetColor(Color.white);

        underTextImage.enabled = false;

        dragOffset = Vector2.zero;
    }
}
