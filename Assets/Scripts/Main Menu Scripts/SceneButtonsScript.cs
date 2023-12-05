using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneButtonsScript : MonoBehaviour
{
    [SerializeField] CanvasGroup mainMenuCanvasGroup;
    
    private float rateOfFade = 0.8f;
    private bool buttonPressed = false;
    // Start is called before the first frame update
    void Start()
    {
        
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
        StartCoroutine(FadeToNextScene(2f, 2));
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
}
