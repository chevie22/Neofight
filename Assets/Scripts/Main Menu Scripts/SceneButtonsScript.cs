using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class SceneButtonsScript : MonoBehaviour
{
    [SerializeField] CanvasGroup mainMenuCanvasGroup;
    
    private float rateOfFade = 0.8f;
    private bool buttonPressed = false;


    //achievement
    [SerializeField] public GameObject panel;
    public CreateAchievement[] newAchievement;
    public TMPro.TextMeshProUGUI title;

    // Start is called before the first frame update
    void Start()
    {
        //JSON
        //index 0 achievement = player achievement
        LoadFromJson(0);
    }

    // Update is called once per frame
    void Update()
    {
        if(buttonPressed)
        {
            mainMenuCanvasGroup.alpha -= (Time.deltaTime * rateOfFade);
        }

    }

    public void StartGame()
    {
        buttonPressed = true;
        StartCoroutine(FadeToNextScene(2f, 6));
    }

    public void EditQuizAndInfo()
    {
        buttonPressed = true;
        StartCoroutine(FadeToNextScene(2f, 1));
    }

    public void Achievements()
    {
        buttonPressed = true;
        StartCoroutine(FadeToNextScene(2f, 5));
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

    IEnumerator FadeToNextScene(float waitTime, int sceneIndex)
    {
        yield return new WaitForSeconds(waitTime);  
        SceneManager.LoadScene(sceneIndex); 
    }



    //achievements JSON
    //just copy paste
    //the index is the achievement index
    public void LoadFromJson(int index)
    {
        //load json file
        string json = File.ReadAllText(Application.dataPath + "/json/AchievementJSON.json");
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
        File.WriteAllText(Application.dataPath + "/json/AchievementJSON.json", json);
    }

    IEnumerator AchievementNotify(float waitTime, Animator animator)
    {
        yield return new WaitForSeconds(waitTime); 
        Debug.Log("open animator"); 
        animator.SetBool("open", false);
    }
}
