using UnityEngine;
using System.Collections;
using System.IO.Ports;
using System;
using UnityEngine.UI;

public class NfcReader : MonoBehaviour
{


    SerialPort stream = new SerialPort("COM3", 9600); //Set the port (com4) and the baud rate (9600, is standard on most devices)
    
    int state = 0;




    void Start()
    {

        stream.Open(); //Open the Serial Stream.
        stream.ReadTimeout = 100;

    }

    // Update is called once per frame

    void Update()
    {

         //Read the information
        try
        {
            string value = stream.ReadLine();
            string[] input = value.Split('\n');
            foreach(string s in input)
            {
                if (s.Length > 5)
                {
                    string ind = s.Substring(0, 6);
                    if(ind == "floppy")
                    {
                        int last = s[s.Length - 1];
                        Debug.Log("Open Document Writer");
                        //if (number == 1){
                         //   Debug.Log("Open Document Writer");
                        //}
                    }
                }
            }
            //Debug.Log(value);
            // do other stuff with the data
        }
        catch (TimeoutException)
        {
            // no-op, just to silence the timeouts. 
            // (my arduino sends 12-16 byte packets every 0.1 secs)
        }

        //stream.BaseStream.Flush();

    }



    void OnGUI()

    {

        string newString = "Connected: ";

        GUI.Label(new Rect(10, 10, 300, 100), newString); //Display new values


    }

}