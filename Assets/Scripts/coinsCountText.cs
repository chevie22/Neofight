using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class coinsCountText : MonoBehaviour
{
    public GameObject[] numbers;
    public PlayerMovement playerMovementScript;
    public TMPro.TextMeshProUGUI m_MyText;
    // Start is called before the first frame update
    void Start()
    {
        //m_MyText.text = "Keys: " + playerMovementScript.coinsCount.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        switch (playerMovementScript.coinsCount)
        {
            case 0:
                numbers[playerMovementScript.coinsCount].gameObject.SetActive(true);
                break;
            case 1:
                numbers[playerMovementScript.coinsCount].gameObject.SetActive(true);
                break;
            case 2:
                numbers[playerMovementScript.coinsCount].gameObject.SetActive(true);
                break;
            case 3:
                numbers[playerMovementScript.coinsCount].gameObject.SetActive(true);
                break;
            case 4:
                numbers[playerMovementScript.coinsCount].gameObject.SetActive(true);
                break;
            case 5:
                numbers[playerMovementScript.coinsCount].gameObject.SetActive(true);
                break;
            
            default:
                // Code to be executed if expression doesn't match any case
                numbers[2].gameObject.SetActive(true);
                break;
        }
    }

   
}
