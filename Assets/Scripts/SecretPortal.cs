using System.Net.Mime;
using System.Net;
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

    //achievement
    [SerializeField] public GameObject panel;
    public CreateAchievement[] newAchievement;
    public TMPro.TextMeshProUGUI title;
    private string jsonFilePath;

    void Start()
    {
        jsonFilePath = Path.Combine(Application.persistentDataPath, "AchievementJSON.json");
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
        string json = File.ReadAllText(jsonFilePath);
        AchievementJson data = JsonUtility.FromJson<AchievementJson>(json);

        bool[] loadData;
        bool[] loadNotify;
        loadData = new bool[4];
        loadNotify = new bool[4];
        for(int i = 0; i < 4; i++)
        {
            loadData[i] = data.achievementUnlock[i];
            loadNotify[i] = data.achievementNotify[i];
        }
        loadData[index] = true;

        //if they got the achievement but no notification then notify
        if (loadData[index] && !loadNotify[index])
        {
            Debug.Log("open panel");
            Animator animator = panel.GetComponent<Animator>();
            if(animator != null)
            {
                //pop notification of new achievement
                title.text = newAchievement[index].name;
                animator.SetBool("open", true);
                loadNotify[index] = true;
                StartCoroutine(AchievementNotify(5, animator));
            }

        }

        SaveToJson(loadData, loadNotify);
    }

    public void SaveToJson(bool[] loadData, bool[]loadNotify)
    {
        AchievementJson data = new AchievementJson();
        data.achievementUnlock = new bool[4];
        data.achievementNotify = new bool[4];

        for(int i = 0; i < 4; i++)
        {
            data.achievementUnlock[i] = loadData[i];
            data.achievementNotify[i] = loadNotify[i];
        }

        string json = JsonUtility.ToJson(data,true);
        File.WriteAllText(jsonFilePath, json);
    }

    IEnumerator AchievementNotify(float waitTime, Animator animator)
    {
        yield return new WaitForSeconds(waitTime); 
        Debug.Log("open animator"); 
        animator.SetBool("open", false);
    }
}