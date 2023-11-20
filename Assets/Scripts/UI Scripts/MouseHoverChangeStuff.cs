using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MouseHoverChangeStuff : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    public float rateOfFade = 0.5f;

    private bool mouse_over = false;
    private bool mouse_clicked = false;

    [SerializeField] private GameObject panelGameObject;
    [SerializeField] private GameObject arrowGameObject;

    [SerializeField] private CanvasGroup panelCanvasGroup;
    [SerializeField] private RawImage arrowImage;

    bool isScaling = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (mouse_over == true)
        {
            panelCanvasGroup.alpha += (Time.deltaTime * rateOfFade);
        }

        if (mouse_over == false && panelCanvasGroup.alpha >= 0.6f)
        {
            panelCanvasGroup.alpha -= (Time.deltaTime * rateOfFade);
        }

        if(mouse_clicked == true)
        {
            StartCoroutine(scaleOverTime(panelGameObject.transform, arrowGameObject.transform, new Vector3(0.9f, 0.9f, 0.9f), 0.2f));

        }

        if (mouse_clicked == false)
        {
            StartCoroutine(scaleOverTime(panelGameObject.transform, arrowGameObject.transform, new Vector3(1f, 1f, 1f), 0.2f));

        }

        Debug.Log(mouse_clicked);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouse_over = true;
        Debug.Log("Mouse enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouse_over = false;
        Debug.Log("Mouse exit");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        mouse_clicked = true;
        Debug.Log(this.gameObject.name + " Was Clicked.");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        mouse_clicked = false;
        Debug.Log(this.gameObject.name + " Was Released.");
    }

    IEnumerator scaleOverTime(Transform objectToScale, Transform objectToScale2, Vector3 toScale, float duration)
    {
        //Make sure there is only one instance of this function running
        if (isScaling)
        {
            yield break; ///exit if this is still running
        }
        isScaling = true;

        float counter = 0;

        //Get the current scale of the object to be moved
        Vector3 startScaleSize = objectToScale.localScale;

        while (counter < duration)
        {
            counter += Time.deltaTime * 3;
            objectToScale.localScale = Vector3.Lerp(startScaleSize, toScale, counter / duration);
            objectToScale2.localScale = Vector3.Lerp(startScaleSize, toScale, counter / duration);
            yield return null;
        }

        isScaling = false;
    }
}

