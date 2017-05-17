using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenubarItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    protected Sprite SourceSprite { get { return sourceImage.sprite; } }
    protected Sprite PressedSprite { get { return button.spriteState.pressedSprite; } }
    protected Sprite HighlightedSprite { get { return button.spriteState.highlightedSprite; } }

    [HideInInspector] public bool IsPressed { protected set; get; }
    [HideInInspector] public bool IsHovering { protected set; get; }

    private Button button;
    private Image sourceImage;

	void Start ()
	{
	    IsPressed = false;

	    sourceImage = GetComponent<Image>();
        button = GetComponent<Button>();
	    if (button)
	    {
	        button.onClick.AddListener(ProcessClick);
	        button.targetGraphic = null;
	    }
	}

    public void UpdateSprite()
    {
        if (!button)
            return;

        if (IsPressed)
        {
            SetSprite(PressedSprite);
        }
        else
        {
            if (IsHovering)
            {
                SetSprite(HighlightedSprite);
            }
            else
            {
                SetSprite(SourceSprite);
            }
        }
    }

    protected void SetSprite(Sprite sprite)
    {
        sourceImage.overrideSprite = sprite;
    }

    public void ProcessClick()
    {
        IsPressed = !IsPressed;

        UpdateSprite();
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        IsHovering = true;

        UpdateSprite();
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        IsHovering = false;
        Debug.Log("Pointer Exit!");

        UpdateSprite();
    }
}
