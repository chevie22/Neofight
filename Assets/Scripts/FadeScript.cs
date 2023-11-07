using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeScript : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;

    [SerializeField] private float alphaOpacity = 0.5f;
    [SerializeField] private float rateOfFade = 0.2f;
    [SerializeField] private float waitForFade = 0f;

    private bool waitDone = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitAndMenuAppear(waitForFade));
    }

    // Update is called once per frame
    void Update()
    {
        if (canvasGroup.alpha < alphaOpacity && waitDone)
        {
            canvasGroup.alpha += (Time.deltaTime * rateOfFade);
        }
    }



   
    IEnumerator WaitAndMenuAppear(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        waitDone = true;
    }
}
