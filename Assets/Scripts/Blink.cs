using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityTime = UnityEngine.Time;

public class Blink : MonoBehaviour
{
    public float interval = 2f;

    private float lastpass = 0f;

	void Start () {
		
	}
	
	void Update ()
	{
	    float current = UnityTime.time;
	    if (current > lastpass + interval)
	    {
	        lastpass = current;
            GetComponent<Image>().enabled = !GetComponent<Image>().enabled;
	    }
	}

}
