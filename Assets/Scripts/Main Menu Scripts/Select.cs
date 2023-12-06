using System.Security.AccessControl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Select : MonoBehaviour
{
    int buttonPressed = -1;

    void Start() 
    {

    }
    void Update() 
    {
        switch (buttonPressed)
        {
            case 0:
                SceneManager.LoadScene(2);
                break;
            
            default:
                // Code to be executed if expression doesn't match any case
                break;
        }
    }


    public void Selected0()
    {
        buttonPressed = 0;   
    }
}
