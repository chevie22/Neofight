using System.Net.Mime;
using System.Net;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.SceneManagement;

public class Initiation2 : MonoBehaviour
{
    private string jsonFilePath2;

    // Start is called before the first frame update
    void Start()
    {
        jsonFilePath2 = Path.Combine(Application.persistentDataPath, "defaultInformation2.json");
        CreateQuizDefaultJson();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateQuizDefaultJson()
    {
        if (!(File.Exists(jsonFilePath2)))
        {
            //save written text into a json file
            InformationData data = new InformationData();

            data.Title = new string[5];
            data.Description = new string[5];
            data.Choices = new string[5*4];
            data.correctAnswerNumber = new int[5];

            data.Title[0] = "API";
            data.Title[1] = "Cloud Computing";
            data.Title[2] = "Malware";
            data.Title[3] = "Cache";
            data.Title[4] = "GUI";

            data.Description[0] = "A set of rules and protocols that allows different software applications to communicate and interact with each other.";
            data.Description[1] = "The delivery of computing services and resources over the internet, such as storage and processing power.";
            data.Description[2] = "Malicious software designed to harm, disrupt, or gain unauthorized access to a computer or network.";
            data.Description[3] = "Temporary storage that stores frequently accessed data for quicker retrieval, enhancing system performance.";
            data.Description[4] = "A visual interface allowing users to interact with software through graphical elements like icons and buttons.";

            data.Choices[0] = "Cloud Computing";
            data.Choices[1] = "API";
            data.Choices[2] = "Cache";
            data.Choices[3] = "Malware";

            data.Choices[4] = "Cloud Computing";
            data.Choices[5] = "Cache";
            data.Choices[6] = "API";
            data.Choices[7] = "GUI";

            data.Choices[8] = "Cache";
            data.Choices[9] = "Malware";
            data.Choices[10] = "GUI";
            data.Choices[11] = "API";

            data.Choices[12] = "API";
            data.Choices[13] = "Cache";
            data.Choices[14] = "Cloud Computing";
            data.Choices[15] = "Malware";

            data.Choices[16] = "Cache";
            data.Choices[17] = "Malware";
            data.Choices[18] = "Cloud Computing";
            data.Choices[19] = "GUI";

            data.correctAnswerNumber[0] = 2;
            data.correctAnswerNumber[1] = 1;
            data.correctAnswerNumber[2] = 2;
            data.correctAnswerNumber[3] = 2;
            data.correctAnswerNumber[4] = 4;


            string json = JsonUtility.ToJson(data,true);
            File.WriteAllText(jsonFilePath2, json);
        }
    }
}
