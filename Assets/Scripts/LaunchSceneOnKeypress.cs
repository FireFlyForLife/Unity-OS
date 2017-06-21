using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaunchSceneOnKeypress : MonoBehaviour
{
    public KeyCode[] Keys;
    public int SceneToSwitch;
	
	void Update () {
	    if (AreAllKeysPressed())
	    {
	        SceneManager.LoadScene(SceneToSwitch);
	    }
	}

    bool AreAllKeysPressed()
    {
        foreach (KeyCode code in Keys)
        {
            if (!Input.GetKey(code))
                return false;
        }

        return true;
    }
}
