using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class QuizCheckerScrip : MonoBehaviour
{
    public int answerPressed = 0;
    public int currentQuestion = 1;

    private int[] correctAnswerNumber;
    private string[] questionTexts;

    [SerializeField] GameObject[] questionPrompts;

    [Header("Button And Question Texts")]
    public TMPro.TextMeshProUGUI questionText;
    public TMPro.TextMeshProUGUI buttonText1;
    public TMPro.TextMeshProUGUI buttonText2;
    public TMPro.TextMeshProUGUI buttonText3;
    public TMPro.TextMeshProUGUI buttonText4;




    void Start()
    {
        //initialize prompts and answers (initialize using json file later)

        //set question prompts of each question (initialize using json file later)
        questionTexts = new string[5];
        questionTexts[0] = "Hello Swagster1";
        questionTexts[1] = "Hello Swagster2";
        questionTexts[2] = "Hello Swagster3";
        questionTexts[3] = "Hello Swagster4";
        questionTexts[4] = "Hello Swagster5";

        questionText.text = questionTexts[currentQuestion - 1];

        //set correct answers of each question (initialize using json file later)
        correctAnswerNumber = new int[5];
        correctAnswerNumber[0] = 1;
        correctAnswerNumber[1] = 2;
        correctAnswerNumber[2] = 3;
        correctAnswerNumber[3] = 4;
        correctAnswerNumber[4] = 1;
    }


    void Update()
    {
        //if correct answer is pressed, proceed to next question
        if(currentQuestion < 6 && answerPressed == correctAnswerNumber[currentQuestion - 1])
        {
            NextQuestion();
        }
        //if all questions are answered correctly, proceed to next level
        if(currentQuestion >= 6)
        {
            NextLevel();
        }
    }

    //next question function
    public void NextQuestion()
    {
        answerPressed = 0;
        currentQuestion++;
        questionText.text = questionTexts[currentQuestion - 1];
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
}
