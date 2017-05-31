using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ConsoleInput : MonoBehaviour, ISubmitHandler
{
    private RectTransform rectTransform;

    private InputField inputField;
    [SerializeField] private Text outputLog;

    void Start ()
    {
        rectTransform = GetComponent<RectTransform>();
        outputLog = GetComponent<Text>();
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
