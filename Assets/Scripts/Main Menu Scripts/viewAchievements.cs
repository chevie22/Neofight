using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class viewAchievements : MonoBehaviour
{
    [SerializeField] private GameObject[] starsObject;
    [SerializeField] private buttonAchievements button;
    

    private bool dialogOn = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //check if the button was clicked or not
        if(button.starButtonNum >= 0 && dialogOn == false)
        {
            //close all dialog
            for(int i = 0; i < 4; i++)
            {   
                starsObject[i].gameObject.SetActive(false);
            }
            //open the clicked star's dialog
            starsObject[button.starButtonNum].gameObject.SetActive(true);
            dialogOn = true;
            button.starButtonNum = -1;
        }
        //if its the dialog is open and was clicked, then turn it off
        if(button.starButtonNum >= 0 && dialogOn)
        {
            starsObject[button.starButtonNum].gameObject.SetActive(false);
            dialogOn = false;
            button.starButtonNum = -1;
        }
 

    }
}
