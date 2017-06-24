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

        public Texture iconTexture;
        public String undersideText = "Program.exe";
        public GameObject program;

        private Vector2 dragOffset = Vector2.zero;

        private bool selected;
        public bool Selected
        {
            get
            {
                return selected;
            }
            set
            {
                selected = value;

                if (selected)
                {
                    //remove every icon selected state
                    foreach (var icon in transform.parent.GetComponentsInChildren<DesktopIcon>())
                    {
                        if(icon != this)
                            icon.Selected = false;
                    }

                    enableSelectedAppearance();
                }
                else
                    disableSelectedAppearance();
            }
        }

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

        void enableSelectedAppearance()
        {
            icon.gameObject.GetComponent<CanvasRenderer>().SetAlpha(0.8f);
            icon.gameObject.GetComponent<CanvasRenderer>().SetColor(selectedColor);

            underTextImage.enabled = true;
        }

        void disableSelectedAppearance()
        {
            icon.gameObject.GetComponent<CanvasRenderer>().SetAlpha(1f);
            icon.gameObject.GetComponent<CanvasRenderer>().SetColor(Color.white);

            underTextImage.enabled = false;
        }

        void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
        {
            enableSelectedAppearance();

            dragOffset = (Vector2)transform.position - eventData.position;
        }

        void IDragHandler.OnDrag(PointerEventData eventData)
        {
            transform.position = eventData.position + dragOffset;
        }

        void IEndDragHandler.OnEndDrag(PointerEventData eventData)
        {
            disableSelectedAppearance();

            dragOffset = Vector2.zero;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            //make this one selected
            Selected = true;

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
