using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class QuizCheckerScrip : MonoBehaviour
{
    private int correctAnswerNumber;
    private string[] questionTexts;

    [SerializeField] GameObject[] questionPrompts;

    [Header("Button And Question Texts")]
    public TMPro.TextMeshProUGUI questionText;
    public TMPro.TextMeshProUGUI buttonText1;
    public TMPro.TextMeshProUGUI buttonText2;
    public TMPro.TextMeshProUGUI buttonText3;
    public TMPro.TextMeshProUGUI buttonText4;

    int answerPressed = -1;
    int currentQuestion = 0;




    void Start()
    {
        DisplayInformation();

    }


    void Update()
    {
        //if correct answer is pressed, proceed to next question
        if(currentQuestion < 5 && answerPressed == correctAnswerNumber)
        {
            NextQuestion();
        }
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
        currentQuestion++;
        DisplayInformation();
        Debug.Log("SEIKAI!!");
    }
    //next level function
    public void NextLevel()
    {
        Debug.Log("CONGRATS!! YOU ACED THE TEST LMFAO!!");
    }


    //set answerPressed integer to what button was pressed
    public void OneButtonPressed()
    {
        answerPressed = 1;
    }

    public void TwoButtonPressed()
    {
        answerPressed = 2;
    }

    public void ThreeButtonPressed()
    {
        answerPressed = 3;
    }

    public void FourButtonPressed()
    {
        answerPressed = 4;
    }

    public void DisplayInformation()
    {
        string json = File.ReadAllText(Application.dataPath + "/json/InformationDataFile.json");
        InformationData data = JsonUtility.FromJson<InformationData>(json);
        questionText.text = data.Prompts[currentQuestion];
        correctAnswerNumber = data.correctAnswerNumber[currentQuestion];
        buttonText1.text = data.Choices1[currentQuestion * 4 + 0];
        buttonText2.text = data.Choices1[currentQuestion * 4 + 1];
        buttonText3.text = data.Choices1[currentQuestion * 4 + 2];
        buttonText4.text = data.Choices1[currentQuestion * 4 + 3];
    }
}
