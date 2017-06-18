using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginHandler : MonoBehaviour {
    public GameObject password;
    public GameObject LoadingText;
    public GameObject LoginScreen;
    private InputField passwordtext;
    private bool goscreen = false;
    // Use this for initialization
    void Start () {
        passwordtext = password.GetComponent<InputField>();
	}
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetKey(KeyCode.Return)){
            if (passwordtext.text == "kavep")
            {
                LoginScreen.SetActive(true);
                LoadingText.SetActive(true);
                if (!goscreen)
                {
                    goscreen = true;
                    StartCoroutine(LoginScreenWait());
                    
                }
                
                
            } 
        }
	}
    IEnumerator LoginScreenWait()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(1);
    }
}
