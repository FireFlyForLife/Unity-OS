using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace InGameComputer
{
    public class TaskbarButton : MonoBehaviour
    {
        public string titleInButton {
            set { GetComponentInChildren<Text>().text = value; }
            get { return GetComponentInChildren<Text>().text;  }
        }
        public Window window;
        // Use this for initialization
        void Start()
        {
            GetComponent<Button>().onClick.AddListener(onClick);
        }
        void onClick()
        {
            window.IsMinimized = !window.IsMinimized;
        }
        // Update is called once per frame
        void Update()
        {

        }
    } 
}
