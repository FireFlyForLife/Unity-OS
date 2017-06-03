using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CopyText : MonoBehaviour
{
    public Text from, to;

    public bool useUpdate = false;
    public bool useLateUpdate = true;

    private LayoutElement element;
	
	void Start ()
	{
	    element = GetComponent<LayoutElement>();
	}
	
	void Update () {
	    if (useUpdate)
	    {
	        UpdateText();

	    }
	}

    void LateUpdate()
    {
        if (useLateUpdate)
        {
            UpdateText();
        }
    }

    public void UpdateText()
    {
        string txt = @from.text;
        float width = @from.preferredWidth;

        element.preferredWidth = width;
        to.text = txt;
    }
}
