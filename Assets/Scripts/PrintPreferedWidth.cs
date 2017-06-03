using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrintPreferedWidth : MonoBehaviour
{
    private Text text;
	
	void Start ()
	{
	    text = GetComponent<Text>();
	}
	
	void Update () {
		Debug.Log(text.preferredWidth);
	}
}
