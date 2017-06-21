using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace InGameComputer
{
    public class TaskbarButton : MonoBehaviour
    {
        public string titleInButton
        {
            set { GetComponentInChildren<Text>().text = value; }
            get { return GetComponentInChildren<Text>().text; }
        }
        public Sprite IconInButton
        {
            set { if (transform.childCount > 1) transform.GetChild(1).GetComponent<Image>().sprite = value; }
            get { return transform.childCount > 1 ? transform.GetChild(1).GetComponent<Image>().sprite : null; }
        }

        private Window window;
        public Window Window { set { window = value; SetDecoration(window.tbvars); } get { return window; } }

        public void SetDecoration(Window.startvariables vars)
        {
            titleInButton = vars.buttontext;
            IconInButton = vars.icon;
        }

        void Start()
        {
            GetComponent<Button>().onClick.AddListener(onClick);
        }
        void onClick()
        {
            Window.IsMinimized = !Window.IsMinimized;
        }

        void Update()
        {

        }
    }
}
