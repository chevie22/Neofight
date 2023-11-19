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
    public TMP_InputField titleInputField0;
    public TMP_InputField descriptionInputField0;

    public TMP_InputField titleInputField1;
    public TMP_InputField descriptionInputField1;

    public TMP_InputField titleInputField2;
    public TMP_InputField descriptionInputField2;

    public TMP_InputField titleInputField3;
    public TMP_InputField descriptionInputField3;

    public TMP_InputField titleInputField4;
    public TMP_InputField descriptionInputField4;

    public void SaveToJson()
    {
        //save written text into a json file
        InformationData data = new InformationData();
        data.Title = new string[5];
        data.Description = new string[5];

        data.Title[0] = titleInputField0.text;
        data.Description[0] = descriptionInputField0.text;

        data.Title[1] = titleInputField1.text;
        data.Description[1] = descriptionInputField1.text;

        data.Title[2] = titleInputField2.text;
        data.Description[2] = descriptionInputField2.text;

        data.Title[3] = titleInputField3.text;
        data.Description[3] = descriptionInputField3.text;

        data.Title[4] = titleInputField4.text;
        data.Description[4] = descriptionInputField4.text;

        string json = JsonUtility.ToJson(data,true);
        File.WriteAllText(Application.dataPath + "/json/InformationDataFile.json", json);
    }

    public void LoadFromJson()
    {
        //load json file
        string json = File.ReadAllText(Application.dataPath + "/json/InformationDataFile.json");
        InformationData data = JsonUtility.FromJson<InformationData>(json);


        //read json file and put it into input field texts
        titleInputField0.text = data.Title[0];
        descriptionInputField0.text = data.Description[0];

        titleInputField1.text = data.Title[1];
        descriptionInputField1.text = data.Description[1];

        titleInputField2.text = data.Title[2];
        descriptionInputField2.text = data.Description[2];

        titleInputField3.text = data.Title[3];
        descriptionInputField3.text = data.Description[3];

        titleInputField4.text = data.Title[4];
        descriptionInputField4.text = data.Description[4];
    }

}
