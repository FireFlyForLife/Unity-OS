using UnityEngine;
using System.Collections;
using System.IO.Ports;
using System;
using UnityEngine.UI;

public class NfcReader : MonoBehaviour
{

    public string portname = "COM3";
    public GameObject DocumentWriterProgram;
    public GameObject HackerMiniGame1;
    public GameObject HackerMiniGame2;
    public GameObject DetonateNukesProgram;
    SerialPort stream; //Set the port (com4) and the baud rate (9600, is standard on most devices)

    int state = 0;

    void Start()
    {
        stream = new SerialPort(portname, 9600);
        try
        {
            stream.Open(); //Open the Serial Stream.

        }
        catch (Exception ex)
        {
            Debug.Log("Error opening NFC Reader: " + ex.Message.ToString());
        }
        stream.ReadTimeout = 100;


    }

    // Update is called once per frame

    void Update()
    {
        if (stream.IsOpen)
        {
            //Read the information
            try
            {
                string value = stream.ReadLine();
                string[] input = value.Split('\n');
                foreach (string s in input)
                {
                    if (s.Length > 5)
                    {
                        string ind = s.Substring(0, 6);
                        if (ind == "floppy")
                        {

                            int program = int.Parse(s.Substring(6, 1));
                            switch (program)
                            {
                                case 1:
                                    Debug.Log("Open Document Writer");
                                    break;
                                case 2:
                                    Debug.Log("Open Hacking Minigame 1");
                                    break;
                                case 3:
                                    Debug.Log("Open Hacking Minigame 2");
                                    break;
                                case 4:
                                    Debug.Log("Open Detonate Nukes Program");
                                    break;
                            }
                        }
                    }
                }

                // do other stuff with the data
            }
            catch (TimeoutException e)
            {
                // no-op, just to silence the timeouts. 
                // (my arduino sends 12-16 byte packets every 0.1 secs)
            }
        }
        //stream.BaseStream.Flush();

    }

}