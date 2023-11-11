using System;
using System.Security.AccessControl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class JsonReadWriteSystem : MonoBehaviour
{
    public TMP_InputField titleInputField;
    public TMP_InputField descriptionInputField;
    //public InputField titleInputField;
    //public InputField descriptionInputField;

    public void SaveToJson()
    {
        InformationData data = new InformationData();
        data.Title = titleInputField.text;
        data.Description = descriptionInputField.text;

        string json = JsonUtility.ToJson(data,true);
        File.WriteAllText(Application.dataPath + "/json/InformationDataFile.json", json);
    }

    public void LoadFromJson()
    {
        string json = File.ReadAllText(Application.dataPath + "/json/InformationDataFile.json");
        InformationData data = JsonUtility.FromJson<InformationData>(json);

        titleInputField.text = data.Title;
        descriptionInputField.text = data.Description;
    }

}
