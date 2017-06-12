using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ConsoleInput : MonoBehaviour
{
    public string folder = "c:\\>";
#pragma warning restore 0414
    public RectTransform RectTransform {get {return transform as RectTransform;} }

    private InputField inputField;
    private InputFieldEnterSubmit submit;
    [SerializeField] private Text outputLog;

    void Start ()
    {
        inputField = GetComponent<InputField>();
        submit = GetComponent<InputFieldEnterSubmit>();
        submit.EnterSubmit.AddListener(OnSubmit);
    }
	
	void Update () {

	}

    void OnSubmit(string str)
    {
        outputLog.text += Environment.NewLine + inputField.text;
        inputField.text = folder;
        LayoutRebuilder.ForceRebuildLayoutImmediate(transform.parent as RectTransform);
        inputField.Select();
        inputField.ActivateInputField();
        inputField.MoveTextEnd(false);
    }
}
