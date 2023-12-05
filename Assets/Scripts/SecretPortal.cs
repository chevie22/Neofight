using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SecretPortal : MonoBehaviour
{
    public PlayerMovement PMScript;
    public GameObject player;
    public GameObject exit;
    public GameObject canvas;
    [SerializeField] private GameObject menuUI;
    private Vector3 exitPos;
    private bool collided = false;
    void Start()
    {
        exitPos = exit.transform.position;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && collided)
        {
            player.transform.position = exitPos;
            canvas.gameObject.SetActive(true);
            menuUI.SetActive(true);

            //index 3 achievement = SECRET PORTAL
            LoadFromJson(3);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            collided = true;  
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            collided = false;  
        }
    }

    //achievements JSON
    //just copy paste
    //the index is the achievement index
    public void LoadFromJson(int index)
    {
        //load json file
        string json = File.ReadAllText(Application.dataPath + "/json/AchievementJSON.json");
        AchievementJson data = JsonUtility.FromJson<AchievementJson>(json);

        bool[] load;
        load = new bool[4];
        for(int i = 0; i < 4; i++)
        {
            load[i] = data.achievementUnlock[i];
        }
        load[index] = true;

        SaveToJson(load);
    }

    public void SaveToJson(bool[] load)
    {
        AchievementJson data = new AchievementJson();
        data.achievementUnlock = new bool[4];

        for(int i = 0; i < 4; i++)
        {
            data.achievementUnlock[i] = load[i];
        }

        string json = JsonUtility.ToJson(data,true);
        File.WriteAllText(Application.dataPath + "/json/AchievementJSON.json", json);
    }
}