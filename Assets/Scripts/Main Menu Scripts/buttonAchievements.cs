using System.Security.AccessControl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class buttonAchievements : MonoBehaviour
{
    // Start is called before the first frame update
    public int starButtonNum = -1;
    public Image[] image;
    private bool[] load;

    void Start() {
        image[0].color = new Color32(255,255,255,255);
        //load json file
        string json = File.ReadAllText(Application.dataPath + "/json/AchievementJSON.json");
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
}
