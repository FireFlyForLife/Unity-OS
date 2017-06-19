using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace InGameComputer
{
    public class Window : MonoBehaviour
    {
        [Serializable] public class startvariables
        {
            public string title;
            public Sprite icon;
            public string buttontext;
        }
        public TaskbarButton Taskbarbutton;

        public string Title
        {
            set { titleText.text = value; }
            get { return titleText.text; }
        }

        [SerializeField] private startvariables tbvars;

        public Sprite Icon
        {
            set { icon.sprite = value; }
            get { return icon.sprite; }
        }

        public GameObject Root
        {
            get
            {
                Transform tr = transform.Find("Root");
                return tr ? tr.gameObject : null;
            }
        }
        private bool isMinimized;
        public bool IsMinimized
        {
            get
            {
                return isMinimized;
            }

            set
            {
                isMinimized = value;
                gameObject.SetActive(!IsMinimized);
            }
        }
        [SerializeField] private Text titleText;
        [SerializeField] private Image icon;

        void Start()
        {
            if (!titleText) titleText = transform.Find("Header/TitleArea/Text").GetComponent<Text>();
            if (!icon) icon = transform.Find("Header/TitleArea/ProgramIcon").GetComponent<Image>();
            Title = tbvars.title;
            Taskbarbutton.IconInButton = tbvars.icon;
            Taskbarbutton.titleInButton = tbvars.buttontext;
        }

        void Update()
        {

        }
    }

}