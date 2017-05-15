using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonChildrenTranslator : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Vector2 Translation = new Vector2(1, -1);

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i);
            Transform[] transforms = child.GetComponentsInChildren<Transform>();
            foreach (Transform tr in transforms)
            {
                tr.position += (Vector3)Translation;
            }
        }
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i);
            Transform[] transforms = child.GetComponentsInChildren<Transform>();
            foreach (Transform tr in transforms)
            {
                tr.position += (Vector3)(-Translation);
            }
        }
    }
}
