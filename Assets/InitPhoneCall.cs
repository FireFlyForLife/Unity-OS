using System.Collections;
using System.IO.Ports;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InitPhoneCall : MonoBehaviour {

    public AudioSource audiosource;
    public AudioClip ring;
    public AudioClip phonecall;
    public AudioClip phonecall2;
    public bool isRinging = false;
    //public bool launchCode = false;
    public string portname = "COM4";
    SerialPort stream; //Set the port (com4) and the baud rate (9600, is standard on most devices)

    public bool launchCode
    {
        set { launchCode = value; }
        get { return launchCode; }
    }
    // Use this for initialization
    void Start () {
        stream = new SerialPort(portname, 9600);
        try
        {
            stream.Open(); //Open the Serial Stream.

        }
        catch (Exception ex)
        {
            Debug.Log("Error reading switch: " + ex.Message.ToString());
        }
        stream.ReadTimeout = 100;

        StartCoroutine(PhoneCall());
	}

    // Update is called once per frame
    void Update()
    {
        if (stream.IsOpen)
        {
            //Read the information
            try
            {
                if (isRinging)
                {
                    string value = stream.ReadLine();
                    if (value == "start")
                    {
                        audiosource.Stop();
                        if (!launchCode)
                        {
                            audiosource.PlayOneShot(phonecall);
                        } else
                        {
                            audiosource.PlayOneShot(phonecall2);
                        }
                    }
                    isRinging = false;
                }
            }
            catch (TimeoutException e)
            {
                // no-op, just to silence the timeouts. 
                // (my arduino sends 12-16 byte packets every 0.1 secs)
                Debug.Log("Switch timeout: " + e.StackTrace);
            }
        }
    }
    IEnumerator PhoneCall()
    {
        yield return new WaitForSeconds(30);
        audiosource.PlayOneShot(ring);
        isRinging = true;
    }
}
