using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAlpha : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        this.GetComponent<Image>().alphaHitTestMinimumThreshold = 0.1f;
    }
}

