using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerInterface : MonoBehaviour {
    public ContextMenu ContextMenu;

    void Start () {
		
	}
	
	void Update () {
	    if (Input.GetButtonDown("Fire2"))
	    {
	        if (ContextMenu.IsShowing)
	        {
	            ContextMenu.SetEnabled(false);
	        }
	        else
	        {
	            ContextMenu.SetEnabled(true);
	        }
	    }
    }
}
