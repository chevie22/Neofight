using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.SceneManagement;
public class QuizCheckerScrip : MonoBehaviour
{
    [SerializeField] private PlayerMovement PMS;
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
    bool entryInput = true;



    void Start()
    {
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
        Debug.Log("Achievement Unlock !!!!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);      
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

        string json = File.ReadAllText(Application.dataPath + "/json/InformationDataFile.json");
        InformationData data = JsonUtility.FromJson<InformationData>(json);
        if(data.Title[0] == ""){
            DisplayInformationDefault();
            return;
        }
        questionText.text = data.Prompts[currentQuestion];
        correctAnswerNumber = data.correctAnswerNumber[currentQuestion];
        buttonText1.text = data.Choices[currentQuestion * 4 + 0];
        buttonText2.text = data.Choices[currentQuestion * 4 + 1];
        buttonText3.text = data.Choices[currentQuestion * 4 + 2];
        buttonText4.text = data.Choices[currentQuestion * 4 + 3];
    }

     public void DisplayInformationDefault()
    {
        string json = File.ReadAllText(Application.dataPath + "/json/default.json");
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

//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
