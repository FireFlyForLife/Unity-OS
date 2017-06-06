using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


public class Taskbar : MonoBehaviour
{
    public Text timeText;
    public string time;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time = System.DateTime.Now.ToString("hh:mm");
        timeText.text = time.ToString();

        //if (Input.GetMouseButtonDown(1))
        //{
        //    Vector3 clickedPosition = Input.mousePosition;
        //    Debug.Log(clickedPosition);
        //    contextMenuOpen = true;
        //    contextMenu.transform.position = clickedPosition;
        //}
        //if (contextMenuOpen == true && Input.GetMouseButtonDown(0))
        //{
        //    Vector3 clickedPosition = contextMenuReset;
        //    contextMenuOpen = false;
        //    contextMenu.transform.position = clickedPosition;
        //}
        if (Input.GetMouseButtonDown(0))
        {

        }
    }
}
