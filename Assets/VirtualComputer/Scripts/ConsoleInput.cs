using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ConsoleInput : MonoBehaviour, ISubmitHandler
{
#pragma warning disable 0414
    // ReSharper disable once NotAccessedField.Local 
    private RectTransform rectTransform;
#pragma warning restore 0414

    private InputField inputField;
    [SerializeField] private Text outputLog;

    void Start ()
    {
        rectTransform = GetComponent<RectTransform>();
        inputField = GetComponent<InputField>();
    }
	
	void Update () {

	}

    void ISubmitHandler.OnSubmit(BaseEventData eventData)
    {
        outputLog.text += Environment.NewLine + inputField.text;
        LayoutRebuilder.ForceRebuildLayoutImmediate(transform.parent as RectTransform);
    }
}
