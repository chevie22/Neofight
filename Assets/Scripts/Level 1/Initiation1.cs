using System.Net.Mime;
using System.Net;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.SceneManagement;

public class Initiation1 : MonoBehaviour
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
        if (File.Exists(jsonFilePath2))
        {
            // Delete the file
            File.Delete(jsonFilePath2);
            Debug.Log("JSON file deleted successfully.");
        }
        else
        {
            Debug.LogWarning("File not found. Unable to delete.");
        }
    }
}
