using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class InformationViewer : MonoBehaviour
{
    [SerializeField] InGameItem[] info;

    [SerializeField] TMPro.TextMeshProUGUI title;
    [SerializeField] TMPro.TextMeshProUGUI description;
    public PlayerMovement playerMovementScript;

    int currentIndex;

    private void Start()    
    {
        currentIndex = 0;
        DisplayInformation();


    }
    public void OnNextButtonPress()
    {
        currentIndex++;
        if(currentIndex >= playerMovementScript.coinsCount)
        {
            currentIndex = 0;
        }
        DisplayInformation();
    }

    public void OnPreviousButtonPress()
    {
        currentIndex--;
        if(currentIndex < 0) 
        {
            currentIndex = info.Length - 1;
        }
        DisplayInformation();
    }

    public void DisplayInformation()
    {
        string json = File.ReadAllText(Application.dataPath + "/json/InformationDataFile.json");
        InformationData data = JsonUtility.FromJson<InformationData>(json);
        title.text = data.Title[currentIndex];
        description.text = data.Description[currentIndex];
    }
}
