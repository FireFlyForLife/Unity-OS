using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DecryptorProgram : Program
{
    public InputField[] NumFields = new InputField[4];

    [SerializeField] private AudioClip errorAudioClip;

    private Color startingColor = Color.gray;

    void Start ()
	{
	    Window = GetComponent<Window>();

	    if (NumFields.Length > 0)
	        startingColor = NumFields[0].GetComponent<Image>().color;
	}
	
	void Update () {
		
	}

    public void Decrypt()
    {
        //Get the current code
        string code = "";
        foreach (InputField inputField in NumFields)
            code += inputField.text;

        if (code == "0451")
        {
            Debug.Log("Entered the correct code!");

            //popup with the new code for the safe
        }
        else
        {
            Debug.Log("Entered the wrong code!");

            //beep a error sound
            Computer.Audio.PlayOneShot(errorAudioClip);

            //blink the numbers
            StartCoroutine("BlinkNumbers");
        }
    }

    public IEnumerator BlinkNumbers()
    {
        Color errorColor = Color.red;

        int blinkAmount = 2;
        float blinkInterval = 0.25f;

        Image[] images = new Image[NumFields.Length];
        for (var i = 0; i < NumFields.Length; i++)
        {
            InputField inputField = NumFields[i];
            images[i] = inputField.GetComponent<Image>();
        }

        for (int i = 0; i < blinkAmount; i++)
        {
            foreach (Image image in images)
            {
                image.color = errorColor;
            }
            yield return new WaitForSeconds(blinkInterval);
            foreach (Image image in images)
            {
                image.color = startingColor;
            }
            yield return new WaitForSeconds(blinkInterval);
        }
    }
}
