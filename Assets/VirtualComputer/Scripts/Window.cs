using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Window : MonoBehaviour {
    public string Title
    {
        set { titleText.text = value; }
        get { return titleText.text; }
    }

    public Sprite Icon
    {
        set { icon.sprite = value; }
        get { return icon.sprite; }
    }

    [SerializeField] private Text titleText;
    [SerializeField] private Image icon;

    void Start () {
		
	}
	
	void Update () {
		
	}
}
