using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContextMenu : MonoBehaviour
{
    public bool IsShowing { protected set; get; }

    private RectTransform rectTransform;

	void Start ()
	{
	    rectTransform = GetComponent<RectTransform>();
	    LayoutRebuilder.ForceRebuildLayoutImmediate(rectTransform);

	    IsShowing = gameObject.activeInHierarchy;
	}

    public void ToggleEnabled()
    {
        SetEnabled(!IsShowing);
    }

    public void SetEnabled(bool state)
    {
        gameObject.SetActive(state);
        IsShowing = state;
    }

    public void ShowAt(Vector2 mousePosition)
    {
        SetEnabled(true);
        MoveContextMenu(Input.mousePosition);
    }

    public void Close()
    {
        SetEnabled(false);
    }

    void MoveContextMenu(Vector2 mouseLocation)
    {
        Vector2 size = rectTransform.rect.size;
        size.x *= -1;

        int width = Screen.width;
        int height = Screen.height;

        if (width < mouseLocation.x - size.x)
            size.x *= -1;
        else if (0 < mouseLocation.y - size.y)
            size.y *= -1;

        rectTransform.anchoredPosition = mouseLocation - size * 0.5f;
    }

    
}
