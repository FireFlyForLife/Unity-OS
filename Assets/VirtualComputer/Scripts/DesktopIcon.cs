using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace InGameComputer
{
    public class DesktopIcon : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
    {
        public VirtualComputer Computer;

        [SerializeField]
        Color selectedColor;
        [SerializeField]
        RawImage underTextImage;
        [SerializeField]
        RawImage icon;
        [SerializeField]
        Text text;

        [SerializeField]
        public Texture iconTexture;
        [SerializeField]
        public String undersideText = "Program.exe";
        [SerializeField]
        public GameObject program;

        private Vector2 dragOffset = Vector2.zero;

        void Start()
        {
            RefreshAppearence();
        }

        public void RefreshAppearence()
        {
            if (icon) icon.texture = iconTexture;
            if (text) text.text = undersideText;
        }

        void Update()
        {

        }

        void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
        {
            icon.gameObject.GetComponent<CanvasRenderer>().SetAlpha(0.8f);
            icon.gameObject.GetComponent<CanvasRenderer>().SetColor(selectedColor);

            underTextImage.enabled = true;

            dragOffset = (Vector2)transform.position - eventData.position;
        }

        void IDragHandler.OnDrag(PointerEventData eventData)
        {
            transform.position = eventData.position + dragOffset;
        }

        void IEndDragHandler.OnEndDrag(PointerEventData eventData)
        {
            icon.gameObject.GetComponent<CanvasRenderer>().SetAlpha(1f);
            icon.gameObject.GetComponent<CanvasRenderer>().SetColor(Color.white);

            underTextImage.enabled = false;

            dragOffset = Vector2.zero;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.clickCount >= 2)
            {
                if (program)
                {
                    program.SetActive(true);
                }
                eventData.clickTime = 0;
                eventData.clickCount = 0;
            }
        }
    } 
}
