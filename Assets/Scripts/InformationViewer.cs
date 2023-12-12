using System.Net;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class InformationViewer : MonoBehaviour
{
    [SerializeField] GameObject keyInventory;
    [SerializeField] InGameItem[] info;

    [SerializeField] TMPro.TextMeshProUGUI title;
    [SerializeField] TMPro.TextMeshProUGUI description;
    public PlayerMovement playerMovementScript;

    int currentIndex;
    private string jsonFilePath2;
    private string jsonFilePath3;

    private void Start()    
    {
        //json file path
        jsonFilePath2 = Path.Combine(Application.persistentDataPath, "defaultInformation.json");
        jsonFilePath3 = Path.Combine(Application.persistentDataPath, "InformationDataFile.json");
        currentIndex = 0;
        DisplayInformation();


    }

    void Update()
    {
        if(keyInventory.activeSelf)
        {
            if(Input.GetKeyDown(KeyCode.D))
            {
                currentIndex++;
                if(currentIndex >= playerMovementScript.coinsCount)
                {
                    currentIndex = 0;
                }
                DisplayInformation();
            }

        }
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
        if(!(File.Exists(jsonFilePath3))){
            DisplayInformationDefault();
            return;
        }
        string json = File.ReadAllText(jsonFilePath3);
        InformationData data = JsonUtility.FromJson<InformationData>(json);
        title.text = data.Title[currentIndex];
        description.text = data.Description[currentIndex];
    }

    public void DisplayInformationDefault()
    {
        string json = File.ReadAllText(jsonFilePath2);
        InformationData data = JsonUtility.FromJson<InformationData>(json);
        title.text = data.Title[currentIndex];
        description.text = data.Description[currentIndex];
    }
}
