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


    [Header("Prompt input field")]
    public TMP_InputField[] promptInputField;

    [Header("Da Choices 1")]
    public TMP_InputField[] choicesInputField;

    [Header("Da Choices 2")]
    public TMP_InputField[] choices2InputField;

    [Header("Da Choices 3")]
    public TMP_InputField[] choices3InputField;

    [Header("Da Choices 4")]
    public TMP_InputField[] choices4InputField;

    [Header("Da Choices 5")]
    public TMP_InputField[] choices5InputField;

    [Header("Correct Answers")]
    public GameObject[] correctAnswerNumberToggled;


    [Header("Title and Description Fields")]
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


    void Start()
    {
        string streamingAssetsPath = Path.Combine(Application.streamingAssetsPath, "original_data.json");
        string persistentDataPath = Path.Combine(Application.persistentDataPath, "modified_data.json");
    }


    public void SaveToJson()
    {
        //save written text into a json file
        InformationData data = new InformationData();

        //question prompts storing ^-^
        data.Prompts = new string[5];

        for(int i = 0; i < 5; i++)
        {
            data.Prompts[i] = promptInputField[i].text;
        }
        
        /*data.Prompts[0] = promptInputField[0].text;
        data.Prompts[1] = promptInputField[1].text;
        data.Prompts[2] = promptInputField[2].text;
        data.Prompts[3] = promptInputField[3].text;
        data.Prompts[4] = promptInputField[4].text;*/

        //store the 4 choices of every question
        data.Choices = new string[5*4];
        //data.Choices2 = new string[4];
        //data.Choices3 = new string[4];
        //data.Choices4 = new string[4];
        //data.Choices5 = new string[4];

        //Only God knows
        int index = 0;
        for(int i = 0;i < 4; i++)
        {
            data.Choices[i] = choicesInputField[i].text;
        }
        index++;
        for(int i = 0;i < 4; i++)data.Choices[index*4+i] = choices2InputField[i].text;
        index++;
        for(int i = 0;i < 4; i++)data.Choices[index*4+i] = choices3InputField[i].text;
        index++;
        for(int i = 0;i < 4; i++)data.Choices[index*4+i] = choices4InputField[i].text;
        index++;
        for(int i = 0;i < 4; i++)data.Choices[index*4+i] = choices5InputField[i].text;

        /*data.Choices1[0] = choices1InputField[0].text;
        data.Choices1[1] = choices1InputField[1].text;
        data.Choices1[2] = choices1InputField[2].text;
        data.Choices1[3] = choices1InputField[3].text;


        data.Choices2[0] = choices2InputField[0].text;
        data.Choices2[1] = choices2InputField[1].text;
        data.Choices2[2] = choices2InputField[2].text;
        data.Choices2[3] = choices2InputField[3].text;

        data.Choices3[0] = choices3InputField[0].text;
        data.Choices3[1] = choices3InputField[1].text;
        data.Choices3[2] = choices3InputField[2].text;
        data.Choices3[3] = choices3InputField[3].text;

        data.Choices4[0] = choices4InputField[0].text;
        data.Choices4[1] = choices4InputField[1].text;
        data.Choices4[2] = choices4InputField[2].text;
        data.Choices4[3] = choices4InputField[3].text;

        data.Choices5[0] = choices5InputField[0].text;
        data.Choices5[1] = choices5InputField[1].text;
        data.Choices5[2] = choices5InputField[2].text;
        data.Choices5[3] = choices5InputField[3].text;*/


        //store answer index of every question
        data.correctAnswerNumber = new int[5];

        //Get toggle components in children of the parent, get what toggle is currently on in togglegroup and set correct answernumber to each question (1-5)
        Toggle[] toggles1 = correctAnswerNumberToggled[0].GetComponentsInChildren<Toggle>();
        foreach (var t1 in toggles1)
            if (t1.isOn)
            {
                switch (t1.name)
                {
                    case "Choice1Toggle":
                        data.correctAnswerNumber[0] = 1;
                        break;
                    case "Choice2Toggle":
                        data.correctAnswerNumber[0] = 2;
                        break;
                    case "Choice3Toggle":
                        data.correctAnswerNumber[0] = 3;
                        break;
                    case "Choice4Toggle":
                        data.correctAnswerNumber[0] = 4;
                        break;

                }
            }

        Toggle[] toggles2 = correctAnswerNumberToggled[1].GetComponentsInChildren<Toggle>();
        foreach (var t2 in toggles2)
            if (t2.isOn)
            {
                switch (t2.name)
                {
                    case "Choice1Toggle":
                        data.correctAnswerNumber[1] = 1;
                        break;
                    case "Choice2Toggle":
                        data.correctAnswerNumber[1] = 2;
                        break;
                    case "Choice3Toggle":
                        data.correctAnswerNumber[1] = 3;
                        break;
                    case "Choice4Toggle":
                        data.correctAnswerNumber[1] = 4;
                        break;

                }
            }

        Toggle[] toggles3 = correctAnswerNumberToggled[2].GetComponentsInChildren<Toggle>();
        foreach (var t3 in toggles3)
            if (t3.isOn)
            {
                switch (t3.name)
                {
                    case "Choice1Toggle":
                        data.correctAnswerNumber[2] = 1;
                        break;
                    case "Choice2Toggle":
                        data.correctAnswerNumber[2] = 2;
                        break;
                    case "Choice3Toggle":
                        data.correctAnswerNumber[2] = 3;
                        break;
                    case "Choice4Toggle":
                        data.correctAnswerNumber[2] = 4;
                        break;

                }
            }

        Toggle[] toggles4 = correctAnswerNumberToggled[3].GetComponentsInChildren<Toggle>();
        foreach (var t4 in toggles4)
            if (t4.isOn)
            {
                switch (t4.name)
                {
                    case "Choice1Toggle":
                        data.correctAnswerNumber[3] = 1;
                        break;
                    case "Choice2Toggle":
                        data.correctAnswerNumber[3] = 2;
                        break;
                    case "Choice3Toggle":
                        data.correctAnswerNumber[3] = 3;
                        break;
                    case "Choice4Toggle":
                        data.correctAnswerNumber[3] = 4;
                        break;

                }
            }

        Toggle[] toggles5 = correctAnswerNumberToggled[4].GetComponentsInChildren<Toggle>();
        foreach (var t5 in toggles5)
            if (t5.isOn)
            {
                switch (t5.name)
                {
                    case "Choice1Toggle":
                        data.correctAnswerNumber[4] = 1;
                        break;
                    case "Choice2Toggle":
                        data.correctAnswerNumber[4] = 2;
                        break;
                    case "Choice3Toggle":
                        data.correctAnswerNumber[4] = 3;
                        break;
                    case "Choice4Toggle":
                        data.correctAnswerNumber[4] = 4;
                        break;

                }
            }


        //store title and description during game 
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
        //File.WriteAllText(persistentDataPath, json);
        File.WriteAllText(Application.dataPath + "/json/InformationDataFile.json", json);
    }

    public void LoadFromJson()
    {
        //load json file
        //string json = File.ReadAllText(Application.dataPath + "/json/InformationDataFile.json");
        string json = File.ReadAllText(Application.dataPath + "/StreamingAssets/InformationDataFile.json");
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
