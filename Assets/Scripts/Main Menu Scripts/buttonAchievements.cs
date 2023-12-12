using System.Net;
using System.Security.AccessControl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class buttonAchievements : MonoBehaviour
{
    // Start is called before the first frame update
    public int starButtonNum = -1;
    public Image[] image;
    private bool[] load;
    private string jsonFilePath;

    void Start() {
        //load json file
        jsonFilePath = Path.Combine(Application.persistentDataPath, "AchievementJSON.json");
        string json = File.ReadAllText(jsonFilePath);
        AchievementJson data = JsonUtility.FromJson<AchievementJson>(json);

        load = new bool[4];
        for(int i = 0; i < 4; i++)
        {
            load[i] = data.achievementUnlock[i];
            if(load[i])
            {
                image[i].color = new Color32(255,255,255,255);
            }
            else{
                image[i].color = new Color32(0,0,0,255);
            }
        }
    }
    public void star0()
    {
        if(load[0])starButtonNum = 0;
    }
    public void star1()
    {
        if(load[1])starButtonNum = 1;
    }
    public void star2()
    {
        if(load[2])starButtonNum = 2;
    }
    public void star3()
    {
       if(load[3]) starButtonNum = 3;
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
