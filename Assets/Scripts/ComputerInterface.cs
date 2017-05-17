using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerInterface : MonoBehaviour {
    public ContextMenu ContextMenu;

    void Start () {
		ContextMenu.gameObject.SetActive(false);
	}
	
	void Update () {
	    if (Input.GetButtonDown("Fire2"))
	    {
	        if (ContextMenu.IsShowing)
	        {
	            ContextMenu.Close();
	        }
	        else
	        {
	            ContextMenu.ShowAt(Input.mousePosition);
	        }
	    }
    }
}
