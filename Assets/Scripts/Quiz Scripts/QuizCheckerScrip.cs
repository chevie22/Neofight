using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.SceneManagement;
public class QuizCheckerScrip : MonoBehaviour
{
    private int correctAnswerNumber;
    //private string[] questionTexts;

    //[SerializeField] GameObject[] questionPrompts;

    [Header("Button And Question Texts")]
    public TMPro.TextMeshProUGUI questionText;
    public TMPro.TextMeshProUGUI buttonText1;
    public TMPro.TextMeshProUGUI buttonText2;
    public TMPro.TextMeshProUGUI buttonText3;
    public TMPro.TextMeshProUGUI buttonText4;

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
        if(currentQuestion >= 5)
        {
            NextLevel();
            currentQuestion = 0;
        }
    }

    //next question function
    public void NextQuestion()
    {
        answerPressed = -1;
        ifPressed = false;
        currentQuestion++;
        DisplayInformation();
        Debug.Log("SEIKAI!!");
    }
    //next level function
    public void NextLevel()
    {
        SceneManager.LoadScene(4);
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
}

//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
