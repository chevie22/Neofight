using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class display : MonoBehaviour
{
    public Key key;

    public TMPro.TextMeshProUGUI nameText;
    public TMPro.TextMeshProUGUI descriptionText;
     [SerializeField] private Image dialog;
    void Start()
    {
        key.Print();
        nameText.text = key.name;
        descriptionText.text = key.description;

    }


}
