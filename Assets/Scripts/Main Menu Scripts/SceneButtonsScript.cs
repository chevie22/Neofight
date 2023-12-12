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

    private string jsonFilePath;
    private string jsonFilePath2;

    // Start is called before the first frame update
    void Start()
    {
        jsonFilePath = Path.Combine(Application.persistentDataPath, "AchievementJSON.json");
        jsonFilePath2 = Path.Combine(Application.persistentDataPath, "defaultInformation.json");
        // JSON
        // index 0 achievement = player achievement
        CreateAchievementJson();
        CreateQuizDefaultJson();
        LoadFromJson(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (buttonPressed)
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
    }

    IEnumerator FadeToNextScene(float waitTime, int sceneIndex)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(sceneIndex);
    }

    // achievements JSON
    // just copy-paste
    // the index is the achievement index
    public void LoadFromJson(int index)
    {
        if (File.Exists(jsonFilePath))
        {
            // Load json file
            string json = File.ReadAllText(jsonFilePath);
            AchievementJson data = JsonUtility.FromJson<AchievementJson>(json);

            if (data != null && data.achievementUnlock != null && data.achievementNotify != null)
            {
                bool[] loadData = data.achievementUnlock;
                bool[] loadNotify = data.achievementNotify;

                // Ensure the index is within the array bounds
                if (index >= 0 && index < loadData.Length && index < loadNotify.Length)
                {
                    loadData[index] = true;

                    // if they got the achievement but no notification then notify
                    if (loadData[index] && !loadNotify[index])
                    {
                        Debug.Log("open panel");
                        Animator animator = panel.GetComponent<Animator>();
                        if (animator != null)
                        {
                            // pop notification of new achievement
                            title.text = newAchievement[index].name;
                            animator.SetBool("open", true);
                            loadNotify[index] = true;
                            StartCoroutine(AchievementNotify(5, animator));
                        }
                    }

                    SaveToJson(loadData, loadNotify);
                }
                else
                {
                    Debug.LogError("Index out of bounds in LoadFromJson. Index: " + index);
                }
            }
            else
            {
                Debug.LogError("Invalid data or data structure in LoadFromJson.");
            }
        }
        else
        {
            Debug.LogError("Json file not found at: " + jsonFilePath);
        }
    }

    public void SaveToJson(bool[] loadData, bool[] loadNotify)
    {
        AchievementJson data = new AchievementJson
        {
            achievementUnlock = loadData,
            achievementNotify = loadNotify
        };

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(jsonFilePath, json);
    }

    public void CreateAchievementJson()
    {
        if (!(File.Exists(jsonFilePath)))
        {
            //save written text into a json file
            AchievementJson data = new AchievementJson();

            data.achievementUnlock = new bool[4];
            data.achievementNotify = new bool[4];
            for(int i = 0; i < 4; i++)
            {
                data.achievementUnlock[i] = false;
                data.achievementNotify[i] = false;
            }


            string json = JsonUtility.ToJson(data,true);
            //File.WriteAllText(persistentDataPath, json);
            File.WriteAllText(jsonFilePath, json);
        }
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

            data.Title[0] = "Algorithm";
            data.Title[1] = "Database";
            data.Title[2] = "Firewall";
            data.Title[3] = "Encryption";
            data.Title[4] = "HTML";

            data.Description[0] = "A step-by-step set of instructions for solving a specific problem or performing a task in computer programming.";
            data.Description[1] = "A structured collection of data that can be easily accessed, managed, and manipulated.";
            data.Description[2] = "A security system that filters network traffic to protect against unauthorized access or threats.";
            data.Description[3] = "The process of converting data into a code to secure it from unauthorized access.";
            data.Description[4] = "(Hypertext Markup Language) The standard language for creating and displaying web pages";

            data.Choices[0] = "Encryption";
            data.Choices[1] = "Algorithm";
            data.Choices[2] = "Firewall";
            data.Choices[3] = "HTML";

            data.Choices[4] = "Algorithm";
            data.Choices[5] = "HTML";
            data.Choices[6] = "Database";
            data.Choices[7] = "Encryption";

            data.Choices[8] = "Firewall";
            data.Choices[9] = "HTML";
            data.Choices[10] = "Algorithm";
            data.Choices[11] = "Encryption";

            data.Choices[12] = "Database";
            data.Choices[13] = "Algorithm";
            data.Choices[14] = "Firewall";
            data.Choices[15] = "Encryption";

            data.Choices[16] = "HTML";
            data.Choices[17] = "Firewall";
            data.Choices[18] = "Encryption";
            data.Choices[19] = "Database";

            data.correctAnswerNumber[0] = 2;
            data.correctAnswerNumber[1] = 3;
            data.correctAnswerNumber[2] = 1;
            data.correctAnswerNumber[3] = 4;
            data.correctAnswerNumber[4] = 1;


            string json = JsonUtility.ToJson(data,true);
            File.WriteAllText(jsonFilePath2, json);
        }
    }

    IEnumerator AchievementNotify(float waitTime, Animator animator)
    {
        yield return new WaitForSeconds(waitTime);
        Debug.Log("open animator");
        animator.SetBool("open", false);
    }
}
