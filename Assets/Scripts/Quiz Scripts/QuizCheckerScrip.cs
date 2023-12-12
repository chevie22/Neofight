using System.Net.Mime;
using System.Net;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.SceneManagement;
public class QuizCheckerScrip : MonoBehaviour
{
    [SerializeField] private PlayerMovement PMS;
    [SerializeField] public GameObject QuizUI;
    //private string[] questionTexts;

    //[SerializeField] GameObject[] questionPrompts;

    [Header("Button And Question Texts")]
    public TMPro.TextMeshProUGUI questionText;
    public TMPro.TextMeshProUGUI buttonText1;
    public TMPro.TextMeshProUGUI buttonText2;
    public TMPro.TextMeshProUGUI buttonText3;
    public TMPro.TextMeshProUGUI buttonText4;

    private int correctAnswerNumber;
    int answerPressed = -1;
    int currentQuestion = 0;
    bool ifPressed = false;

    //achievement
    [SerializeField] public GameObject panel;
    public CreateAchievement[] newAchievement;
    public TMPro.TextMeshProUGUI title;

    //Loading bar
    [SerializeField] public GameObject loadingBar;
    [SerializeField] public GameObject loadingStatus;
    private string jsonFilePath;
    private string jsonFilePath2;
    private string jsonFilePath3;



    void Start()
    {
        //json file path
        jsonFilePath = Path.Combine(Application.persistentDataPath, "AchievementJSON.json");
        jsonFilePath2 = Path.Combine(Application.persistentDataPath, "defaultInformation.json");
        jsonFilePath3 = Path.Combine(Application.persistentDataPath, "InformationDataFile.json");
        DisplayInformation();
    }


    void Update()
    {
        if(currentQuestion >= 5)
        {
            //BEWARE !!!!
            //!!!
            //!!!!!!!!!
            // THIS IS NOT WORKING !!!!
            //JSON
            //index 1 achievement = first level clear
            LoadFromJson(1);


            //currentQuestion = 0;
            NextLevel();
        }

        if (ifPressed)
        {
            if(answerPressed == correctAnswerNumber) 
            {
                NextQuestion();
            }
            else{
                Debug.Log("まちがったこたえ!!");
                Reset();
            }
            
        }
        //if correct answer is pressed, proceed to next question
        //if(currentQuestion < 5 && answerPressed == correctAnswerNumber)
        //{
        //    NextQuestion();
        //}
        //if all questions are answered correctly, proceed to next level
    }

    //next question function
    public void NextQuestion()
    {
        if(currentQuestion < 5)
        {
            answerPressed = -1;
            ifPressed = false;
            currentQuestion++;
            DisplayInformation();
            Debug.Log("SEIKAI!!");
        }
    }
    //next level function
    public void NextLevel()
    {
        //go to the next lvl
        Debug.Log("Achievement Unlock !!!!");
        QuizUI.gameObject.SetActive(false);
        loadingBar.gameObject.SetActive(true);
        Animator animator = loadingStatus.GetComponent<Animator>();
        animator.SetBool("loading", true);

        StartCoroutine(WaitforNextScene(6, 8));
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);      
    }


    //set answerPressed integer to what button was pressed
    public void OneButtonPressed()
    {
        answerPressed = 1;
        ifPressed = true;
    }

    public void TwoButtonPressed()
    {
        answerPressed = 2;
        ifPressed = true;
    }

    public void ThreeButtonPressed()
    {
        answerPressed = 3;
        ifPressed = true;
    }

    public void FourButtonPressed()
    {
        answerPressed = 4;
        ifPressed = true;
    }

    public void DisplayInformation()
    {
        if(!(File.Exists(jsonFilePath3))){
            DisplayInformationDefault();
            return;
        }
        string json = File.ReadAllText(jsonFilePath3);
        InformationData data = JsonUtility.FromJson<InformationData>(json);
        questionText.text = data.Prompts[currentQuestion];
        correctAnswerNumber = data.correctAnswerNumber[currentQuestion];
        buttonText1.text = data.Choices[currentQuestion * 4 + 0];
        buttonText2.text = data.Choices[currentQuestion * 4 + 1];
        buttonText3.text = data.Choices[currentQuestion * 4 + 2];
        buttonText4.text = data.Choices[currentQuestion * 4 + 3];
    }

     public void DisplayInformationDefault()
    {
        string json = File.ReadAllText(jsonFilePath2);
        InformationData data = JsonUtility.FromJson<InformationData>(json);
        questionText.text = data.Description[currentQuestion];
        correctAnswerNumber = data.correctAnswerNumber[currentQuestion];


        buttonText1.text = data.Choices[currentQuestion * 4 + 0];
        buttonText2.text = data.Choices[currentQuestion * 4 + 1];
        buttonText3.text = data.Choices[currentQuestion * 4 + 2];
        buttonText4.text = data.Choices[currentQuestion * 4 + 3];
    }

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
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

        //acheievement 0 = Player;
        // achievement first time completion
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

     IEnumerator WaitforNextScene(float waitTime, int n)
    {
        yield return new WaitForSeconds(waitTime); 
        SceneManager.LoadScene(n);
    }
}

//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
