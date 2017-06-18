using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupAfterHex1 : MonoBehaviour
{
    public GameObject[] PopupGameObjects;

    private HexGrid grid;
    private bool hasCompleted = false;
	
	void Start ()
	{
	    grid = GetComponent<HexGrid>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (grid.Completed || hasCompleted)
	    {
	        hasCompleted = true;
	        foreach (var obj in PopupGameObjects)
	        {
	            obj.SetActive(true);
	        }
        }
	}
}
