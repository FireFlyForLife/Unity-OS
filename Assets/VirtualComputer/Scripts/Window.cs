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

    public GameObject Root
    {
        get
        {
            Transform tr = transform.Find("Root");
            return tr ? tr.gameObject : null;
        }
    }

    [SerializeField] private Text titleText;
    [SerializeField] private Image icon;

    void Start ()
    {
        if (!titleText) titleText = transform.Find("Header/TitleArea/Text").GetComponent<Text>();
        if (!icon) icon = transform.Find("Header/TitleArea/ProgramIcon").GetComponent<Image>();
    }
	
	void Update () {
		
	}
}
