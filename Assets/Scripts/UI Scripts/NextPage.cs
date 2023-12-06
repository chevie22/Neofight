using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextPage : MonoBehaviour
{
    [SerializeField] private CanvasGroup[] canvasGroup;
    [SerializeField] private GameObject[] pageObject;
    [SerializeField] private float rateOfFade = 0.2f;

    private bool nextPressed = false;
    private bool previousPressed = false;
    private bool fadeToNextNow = false;
    private int currentPageIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        //fade next/previous page (code might be shit too much variables idk how this works TBH!)
        if(currentPageIndex > 0 && nextPressed)
        {
            canvasGroup[currentPageIndex - 1].alpha -= (Time.deltaTime * rateOfFade);
        }

        if(previousPressed)
        {
            canvasGroup[currentPageIndex + 1].alpha -= (Time.deltaTime * rateOfFade);
        }

        if (fadeToNextNow)
        {
            canvasGroup[currentPageIndex].alpha += (Time.deltaTime * rateOfFade);
        }
    }

    //NextPage function when button presses next arrow, do all these
    public void NextPageBro()
    {
        if(currentPageIndex != canvasGroup.Length - 1)
        {
            nextPressed = true;
            fadeToNextNow = false;
            currentPageIndex++;
            canvasGroup[currentPageIndex - 1].alpha = 1f;
            StartCoroutine(NextCountdown(0.3f));
            canvasGroup[currentPageIndex].alpha = 0f;
        }

    }

    //PreviousPage function when button presses previous arrow, do all these
    public void PreviousPageBro()
    {
        if(currentPageIndex != 0)
        {
            previousPressed = true;
            fadeToNextNow = false;
            currentPageIndex--;
            canvasGroup[currentPageIndex + 1].alpha = 1f;
            StartCoroutine(PreviousCountdown(0.3f));
            canvasGroup[currentPageIndex - 1].alpha = 0f;
        }

    }

    //after fade ends, next page active and start fade
    IEnumerator NextCountdown(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        pageObject[currentPageIndex - 1].SetActive(false);
        pageObject[currentPageIndex].SetActive(true);
        fadeToNextNow = true;
        nextPressed = false;
    }

    //after fade ends, previous page active and start fade
    IEnumerator PreviousCountdown(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        pageObject[currentPageIndex + 1].SetActive(false);
        pageObject[currentPageIndex].SetActive(true);
        fadeToNextNow = true;
        previousPressed = false;
    }
}
